using CleanArchitectureTemplate.Application.Common.Exceptions;
using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Resources;
using System;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Users;
using CleanArchitectureTemplate.Application.DTO.V1.Users;
using FluentValidation;

namespace CleanArchitectureTemplate.Application.UseCases.Implementations
{
    public class UserLoginInteractor : IUserLoginUseCase
    {
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IDateTime _dateTime;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;

        public UserLoginInteractor(
            ITokenService tokenService,
            IAuthenticationService authenticationService,
            IDateTime dateTime,
            IUnitOfWork unitOfWork,
            ICurrentUserService currentUserService
            )
        {
            _tokenService = tokenService;
            _authenticationService = authenticationService;
            _dateTime = dateTime;
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<OperationResult> LoginAsync(UserLoginRequestDTO request)
        {
            var authenticationResult = await _authenticationService.AuthenticateUserAsync(request.Email, request.Password!);

            // check user is Authenticated
            if (!authenticationResult.IsUserAuthenticated)
            {
                return OperationResult.Failure(exception: authenticationResult.Exception);

            }
            var claims = authenticationResult.Claims;
            // Create JWT Token for user
            var tokenResult = await _tokenService.GenerateTokenAsync(claims);
            if (!tokenResult.IsSuccess)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.GenerateTokenError);
                return OperationResult.Failure(
                    new TokenGenerationException()
                    .WithMessage(defaultMessage, localizedMessage)
                    .WithInnerCustomException(tokenResult.Exception));

            }
            var currentUserId = _currentUserService.UserId;

            var authenticatedUser = authenticationResult.AuthenticatedUser;

            // Create or Update User Session
            var Session = new Session()
            {
                LastLoggedindAt = _dateTime.TimeStampNow
            };


            // Update or Add
            if (!authenticatedUser!.HasSession(Session))
                authenticatedUser.AddSessions(Session);
            else
                authenticatedUser.UpdateSession(Session);

            try
            {
                var user =  _unitOfWork.UserRepository.Update(authenticatedUser);
                await _unitOfWork.CommitAsync();

                return OperationResult<UserLoginResponseDTO>.Success(new UserLoginResponseDTO()
                {
                    Token = tokenResult.Token!,

                });
            }
            catch (ValidationException ve)
            {
                throw ve;
            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ErrorDuringUserLogin, request.Email);
                return OperationResult.Failure(
                    new ExistEmailException()
                    .WithMessage(defaultMessage, localizedMessage)
                    .WithInnerCustomException(exception)
                    );
            }
        }
    }
}
