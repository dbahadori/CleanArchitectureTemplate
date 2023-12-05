using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserProfileRepository : IBaseRepository<UserProfileEntity , Guid>
    {
    }
}
