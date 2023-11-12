using CleanArchitectureReferenceTemplate.Domain.Entities;

namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserProfileRepository : IBaseRepository<UserProfileEntity , Guid>
    {
    }
}
