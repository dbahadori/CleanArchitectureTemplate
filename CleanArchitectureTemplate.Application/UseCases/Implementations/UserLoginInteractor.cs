using CleanArchitectureTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.DTO.V1;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Application.UseCases.Interfaces;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Resources;
using System;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.UseCases.Implementations
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

        public async Task<OperationResult> LoginAsync(UserLoginInputModel input)
        {
            var authenticationResult = await _authenticationService.AuthenticateUserAsync(input.Email, input.Password!);

            // check user is Authenticated
            if (!authenticationResult.IsUserAuthenticated)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.UserWithEmailNotFound, input.Email);
                if (authenticationResult.AuthenticatedUser == null)
                {
                    return OperationResult.Failure(
                        new NotFoundUserException()
                        .WithUserFriendlyMessage(localizedMessage)
                        .WithDeveloperDetail(defaultMessage));
                }
                (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.PasswordNotCorrect, input.Email);
                return OperationResult.Failure(
                    new PasswordNotCorrectException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage));
            }


            // Create JWT Token for user
            var tokenResult = await _tokenService.GenerateTokenAsync(authenticationResult.AuthenticatedUser!);
            if (!tokenResult.IsSuccess)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.GenerateTokenError);
                return OperationResult.Failure(
                    new TokenGenerationException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(tokenResult.Exception));

            }

            var authenticatedUser = authenticationResult.AuthenticatedUser;

            // Create or Update User Session
            var session = new Session()
            {
                Device = input.Device,
                DeviceHash = input.DeviceHash,
                FireBaseToken = input.FireBaseToken,
                LastLoggedindAt = _dateTime.TimeStampNow
            };


            // Update or Add
            if (!authenticatedUser!.HasSession(session))
                authenticatedUser.AddSessions(session);
            else
                authenticatedUser.UpdateSession(session);

            try
            {
                _unitOfWork.UserRepository.Update(authenticatedUser);
                await _unitOfWork.CommitAsync();
               // var r = await _unitOfWork.UserRepository.SaveAsync();
                return OperationResult<UserLoginOutputModel>.Success(new UserLoginOutputModel()
                {
                    Token = tokenResult.Token!,
                    Email = authenticatedUser.Email,
                    FullName = authenticatedUser.FullName,
                });
            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.ErrorDuringUserLogin, input.Email);
                return OperationResult.Failure(
                    new ExistEmailException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception)
                    );
            }
        }
    }
}
