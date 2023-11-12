using AutoMapper;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;

namespace CleanArchitectureReferenceTemplate.Application.Services.Implementations
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
            var Result = await _unitOfWork.UserRepository.FindByEmailAsync(email);
            if (!Result.IsSuccessful)
            {
                return new AuthenticationResult
                {
                    Exception = new NotFoundUserException(string.Format(Resources.ErrorMessages.UserNotFound, email))
                };
            }

            var userResult = Result as OperationResult<User>;

            var checkPasswordResult = await _unitOfWork.UserRepository.ValidateCredentialsAsync(userResult!.Data!.Email!, password);
            if (!checkPasswordResult.IsSuccessful)
                return new AuthenticationResult { Exception = checkPasswordResult.Exception };

            return new AuthenticationResult() { AuthenticatedUser = userResult.Data!, IsSuccess = true, IsUserAuthenticated = true };

        }
    }
}
