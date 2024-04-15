using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class UserProfileRepository : BaseRepository<UserProfile, Guid>, IUserProfileRepository
    {
        public UserProfileRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
