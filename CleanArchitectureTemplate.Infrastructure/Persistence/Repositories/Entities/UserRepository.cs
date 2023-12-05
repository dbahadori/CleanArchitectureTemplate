using AutoMapper;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureTemplate.Resources;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class UserRepository : BaseRepository<UserEntity, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public async Task CreateUserAsync(User user)
        {
            try
            {
                var userEntity = _mapper.Map<UserEntity>(user);
                await _context.AddAsync(userEntity);
            }
            catch (Exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.ErrorDuringCreatingUser);
                throw new NotFoundException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage);
            }
            
        }

        public async Task<User> FindByIdAsync(Guid userId)
        {
            try
            {
                var user = await _context.Users
               .Include(x => x.Roles)
               .Where(x => x.Id == userId)
               .AsNoTracking()
               .FirstOrDefaultAsync();

                if (user != null)
                {
                    var userModel = _mapper.Map<User>(user);
                    return userModel;
                }

                return null;
            }
            catch (Exception exception )
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalById);
                throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception );
            }
           
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException();

                var user = await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email!.ToUpper() == email.ToUpper());

                if (user != null)
                {
                    var userModel = _mapper.Map<User>(user);
                    return userModel;
                }


                return null;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalByEmail);
                 throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
            
        }

        public async Task<User> GetUserWithProfile(Guid userId)
        {
            try
            {
                var user = await _context.Users
                .Include(x => x.UserProfile)
                .Where(x => x.Id == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

                if (user != null)
                {
                    var userModel = _mapper.Map<User>(user);
                    return userModel;
                }

                return null;

            }
            catch (Exception exception)
            {

                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalById);
                 throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
            
        }

        public async Task<bool> IsEmailExist(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException();
            try
            {
                var userExist = await _context.Users.AsNoTracking().AnyAsync(x => x.Email!.ToUpper() == email.ToUpper());
                return userExist;
            }
            catch (Exception exception)
            {

                var (defaultMessage, localizedMessage) = ResourceHelper.GetErrorMessages(em => ErrorMessages.FaliedToCheckEmail);
                throw  new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }
    }
}
