using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.ValueObejects;
using CleanArchitectureTemplate.Resources;

namespace CleanArchitectureTemplate.Application.Services.Implementations
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AuthenticationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthenticationResult> AuthenticateUserAsync(string email, string password)
        {
            var user = await _unitOfWork.UserRepository.FindByEmailAsync(email);
            if (user==null)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.UserWithEmailNotFound, email);

                return new AuthenticationResult
                {
                    Exception = new NotFoundException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                };
            }
            var isValidPassword = user.ValidatePassword(password);
            if (!isValidPassword)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.PasswordNotCorrect, email);
                return new AuthenticationResult
                {
                    Exception = new PasswordNotCorrectException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                };
            }
 

            return new AuthenticationResult() { 
                AuthenticatedUser = user,
                IsSuccess = true,
                IsUserAuthenticated = true 
            };

        }
    }
}
