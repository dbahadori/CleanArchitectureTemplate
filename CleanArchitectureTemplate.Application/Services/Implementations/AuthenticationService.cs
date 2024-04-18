using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Exceptions;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CleanArchitectureTemplate.Application.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AuthenticationService(
            IUnitOfWork unitOfWork,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<AuthenticationResult> AuthenticateUserAsync(string email, string password)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserWithRolesByUsernameAsync(email);
                if (user == null)
                {
                    var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.UserWithEmailNotFound, email);
                    var errorCode = ResourceHelper.GetGeneralErrorMessageKey(em => ErrorMessages.UserWithEmailNotFound);
                    return new AuthenticationResult
                    {
                        Exception = new NotFoundUserException()
                        .WithUserFriendlyMessage(localizedMessage)
                        .WithDeveloperDetail(defaultMessage)
                        .WithErrorCode(errorCode)
                    };
                }
                var isValidPassword = user.ValidatePassword(password);
                if (!isValidPassword)
                {
                    var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.PasswordNotCorrect, email);
                    var errorCode = ResourceHelper.GetGeneralErrorMessageKey(em => ErrorMessages.PasswordNotCorrect);

                    return new AuthenticationResult
                    {
                        Exception = new PasswordNotCorrectException()
                        .WithUserFriendlyMessage(localizedMessage)
                        .WithDeveloperDetail(defaultMessage)
                        .WithErrorCode(errorCode)
                    };
                }

                // Extract claims from the authenticated user
                var claims = new List<Claim>
                {
/*                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.Id.ToString()),
                    new Claim("roles", string.Join(",", user.Roles))*/
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("roles", string.Join(",", user.Roles))

                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Set the created ClaimsPrincipal as the current user
                _httpContextAccessor.HttpContext.User = principal;

                return new AuthenticationResult()
                {
                    AuthenticatedUser = user,
                    IsSuccess = true,
                    IsUserAuthenticated = true,
                    Claims = claims
                };
            }
            catch (RepositoryException re)
            {
                return new AuthenticationResult
                {
                    Exception = new PasswordNotCorrectException()
                    .WithUserFriendlyMessage(re.UserFriendlyMessage)
                    .WithDeveloperDetail(re.DeveloperDetail)
                    .WithErrorCode(re.ErrorCode)
                };
            }
        }
    }
}
