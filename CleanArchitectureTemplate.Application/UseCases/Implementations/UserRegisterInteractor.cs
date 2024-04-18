using AutoMapper;
using CleanArchitectureTemplate.Application.Common.Exceptions;
using CleanArchitectureTemplate.Application.DTO.V1.AdminControlPanel;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Application.UseCases.Interfaces.Admin;
using CleanArchitectureTemplate.Domain.DTO;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;

using CleanArchitectureTemplate.Resources;

namespace CleanArchitectureTemplate.Application.UseCases.Implementations
{
    public class UserRegisterInteractor : IUserRegisterUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IAuthenticationService _authenticationService;

        public UserRegisterInteractor(ITokenService tokenService, IAuthenticationService authenticationService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        public async Task<OperationResult> RegisterAsync(UserRegisterRequestDTO input, CancellationToken cancellationToken)
        {
            try
            {
                // Check Exist User with this email
                var isEmailDuplicated = await _unitOfWork.UserRepository.IsEmailExistAsync(input.Email, cancellationToken);
                if (isEmailDuplicated)
                {
                    var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ExistEmailBefore, input.Email);
                    return OperationResult.Failure(new ExistEmailException(defaultMessage, localizedMessage));

                }
                // Create User Model
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = input.Email,
                    FullName = input.FullName,
                    UserName = input.Email
                };
                user.SetHashedPassword(input.Password);
                // Create User Profile
                var userProfile = new UserProfile()
                {
                    Id = Guid.NewGuid(),
                };

                user.AddProfile(userProfile);
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.CommitAsync();

                return OperationResult.Success();

            }
            catch (Exception exception)
            {
                _unitOfWork.Rollback();
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ErrorDuringRegistringUser, input.Email);
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
