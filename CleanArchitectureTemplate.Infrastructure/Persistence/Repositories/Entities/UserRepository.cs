using AutoMapper;
using CleanArchitectureTemplate.Domain.Common.Exceptions;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;
using CleanArchitectureTemplate.Resources;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    throw new ArgumentNullException();

                var user = await _dbContext.Users
                    .FirstOrDefaultAsync(x => x.Email!.ToUpper() == email.ToUpper());


                return user;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalByEmail);
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
                var user = await _dbContext.Users
                .Include(x => x.UserProfile)
                .Where(x => x.Id == userId)
                .FirstOrDefaultAsync();

                return user;

            }
            catch (Exception exception)
            {

                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalById);
                 throw new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }
            
        }

        public async Task<bool> IsEmailExistAsync(string email, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException();
            try
            {
                var userExist = await base.ExistsWithConditionsAsync(x => x.Email!.ToUpper() == email.ToUpper(), cancellationToken);
                return userExist;
            }
            catch (Exception exception)
            {

                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.FaliedToCheckEmail);
                throw  new RepositoryException()
                    .WithUserFriendlyMessage(localizedMessage)
                    .WithDeveloperDetail(defaultMessage)
                    .WithInnerCustomException(exception);
            }

        }

        public async Task<User?> GetUserWithRolesByUsernameAsync(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    throw new ArgumentNullException(nameof(userName));

                var user = await _dbContext.Users
                    .AsNoTracking()
                    .Include(x => x.Roles)
                    .Where(x => x.UserName!.ToUpper() == userName.ToUpper())
                    .FirstOrDefaultAsync();


                return user;
            }
            catch (Exception exception)
            {
                var (defaultMessage, localizedMessage) = ResourceHelper.GetGeneralErrorMessages(em => ErrorMessages.ErrorDuringUserRetrievalByEmail);
                throw new RepositoryException()
                   .WithUserFriendlyMessage(localizedMessage)
                   .WithDeveloperDetail(defaultMessage)
                   .WithInnerCustomException(exception);
            }
        }

    }
}
