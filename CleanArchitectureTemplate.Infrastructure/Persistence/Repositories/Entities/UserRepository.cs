using AutoMapper;
using CleanArchitectureReferenceTemplate.Application.Services.Utilities;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;
using CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class UserRepository : BaseRepository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task<OperationResult> CreateUserAsync(User user, string password)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            var passwordHash = UtilityService.CreateSHA512(password);
            userEntity.PasswordHash = passwordHash;

            await _context.AddAsync(userEntity);

            return OperationResult.Success();
        }

        public async Task<OperationResult> ValidateCredentialsAsync(string email, string password)
        {
            var Result = await FindByEmailAsync(email);
            if (!Result.IsSuccessful)
                return Result;

            var userResult = Result as OperationResult<User>;

            var passwordHash = UtilityService.CreateSHA512(password);

            if (passwordHash != userResult!.Data!.PasswordHash)
                return OperationResult.Failure(new PasswordNotCorrectException(email));

            return OperationResult.Success();
        }

        public async Task<OperationResult> FindByIdAsync(Guid userId)
        {
            var user = await _context.Users.Include(x=> x.Roles).Where(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();
            if (user == null)
                return OperationResult.Failure(new NotFoundException("User", userId));

            var userModel = _mapper.Map<User>(user);
            return OperationResult<User>.Success(userModel);
        }

        public async Task<OperationResult> FindByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return OperationResult.Failure(new ArgumentNullException());

            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email!.ToUpper() == email.ToUpper());
            if (user == null)
                return OperationResult.Failure(new NotFoundException("User", email));

            var session = user.Sessions.ToList();
            var userModel = _mapper.Map<User>(user);
            return OperationResult<User>.Success(userModel);
        }

        public async Task<OperationResult> GetUserWithProfile(Guid userId)
        {
            var user = await _context.Users
                .Include(x => x.UserProfile).
                Where(x => x.Id == userId).AsNoTracking().FirstOrDefaultAsync();
            if (user == null)
                return OperationResult.Failure(new NotFoundException("User", userId));

            var userModel = _mapper.Map<User>(user);
            return OperationResult<User>.Success(userModel);
        }

        public async Task<OperationResult> IsEmailExist(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return OperationResult.Failure(new ArgumentNullException());

            var userExist = await _context.Users.AsNoTracking().AnyAsync(x => x.Email!.ToUpper() == email.ToUpper());
            return OperationResult<bool>.Success(userExist);
        }
    }
}
