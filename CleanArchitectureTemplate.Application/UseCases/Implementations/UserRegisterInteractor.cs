using AutoMapper;
using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;
using CleanArchitectureReferenceTemplate.Application.DTO.V1;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Application.UseCases.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;

namespace CleanArchitectureReferenceTemplate.Application.UseCases.Implementations
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

        public async Task<OperationResult> RegisterAsync(UserRegisterInputMessage input)
        {
            try
            {
                // Check Exist User with this email
                var isEmailExistResult = await _unitOfWork.UserRepository.IsEmailExist(input.Email);
                var isEmailExist = isEmailExistResult as OperationResult<bool>;
                if (isEmailExist!.Data)
                    return OperationResult.Failure(new ExistEmailException(input.Email, string.Format(Resources.ErrorMessages.ExistEmailBefore, input.Email)));

                // Create User Model
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = input.Email,
                    FullName = input.FullName,
                    UserName = input.Email
                };

                // Create User Profile
                var userProfile = new UserProfile()
                {
                    Id = Guid.NewGuid(),
                };

                user.AddProfile(userProfile);

                var createUserResult = await _unitOfWork.UserRepository.CreateUserAsync(user, input.Password);
                if (!createUserResult!.IsSuccessful)
                    return createUserResult;

                await _unitOfWork.CommitAsync();

                return createUserResult;

            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
