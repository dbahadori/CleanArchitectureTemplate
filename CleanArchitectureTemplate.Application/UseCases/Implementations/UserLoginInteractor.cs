using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;

namespace CleanArchitectureReferenceTemplate.Application.UseCases.Implementations
{
    public class UserLoginInteractor : IUserLoginUseCase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTime _dateTime;
        private readonly IUnitOfWork _unitOfWork;

        public UserLoginInteractor(ITokenService tokenService, IAuthenticationService authenticationService, IDateTime dateTime, IUnitOfWork unitOfWork)
        {
            _tokenService = tokenService;
            _authenticationService = authenticationService;
            _dateTime = dateTime;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult> LoginAsync(UserLoginInputMessage input)
        {
            var authenticationResult = await _authenticationService.AuthenticateUserAsync(input.Email, input.Password!);

            // check user is Authenticated
            if (!authenticationResult.IsUserAuthenticated)
            {
                if (authenticationResult.AuthenticatedUser == null)
                    return OperationResult.Failure(new NotFoundUserException(string.Format(Resources.ErrorMessages.UserNotFound, input.Email)));

                return OperationResult.Failure(new NotFoundUserException(string.Format(Resources.ErrorMessages.PasswordNotCorrect, input.Email)));
            }


            // Create JWT Token for user
            var tokenResult = await _tokenService.GenerateTokenAsync(authenticationResult.AuthenticatedUser!);
            if (!tokenResult.IsSuccess)
                return OperationResult.Failure(new Exception(string.Format(Resources.ErrorMessages.GenerateTokenError, Resources.ErrorMessages.ConfigFileIsNull)));

            var authenticatedUser = authenticationResult.AuthenticatedUser;

            // Create or Update User Session
            var Session = new Session()
            {
                Device = input.Device,
                DeviceHash = input.DeviceHash,
                FireBaseToken = input.FireBaseToken,
                LastLoggedindAt = _dateTime.TimeStampNow
            };


            // Update or Add
            if (authenticatedUser!.HasSession(Session)) 
                authenticatedUser.UpdateSession(Session);
            else
                authenticatedUser.AddSessions(Session);

            try
            {
                 _unitOfWork.UserRepository.Update(authenticatedUser);
                //await _userRepository.SaveAsync();
                //_unitOfWork.UserRepository.Update(authenticatedUser);
                //await _unitOfWork.CommitAsync();
                var r=await _unitOfWork.UserRepository.SaveAsync(); 
                return OperationResult<UserLoginOutputMessage>.Success(new UserLoginOutputMessage()
                {
                    Token = tokenResult.Token!,
                    Email = authenticatedUser.Email,
                    FullName = authenticatedUser.FullName,
                });
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
