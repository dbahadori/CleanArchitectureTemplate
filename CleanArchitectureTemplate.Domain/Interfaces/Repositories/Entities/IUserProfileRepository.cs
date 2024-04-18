using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IUserProfileRepository :
        IReadableRepository<UserProfile, Guid>,
        IWritableRepository<UserProfile, Guid>,
        IPaginatedRepository<UserProfile>,
        IExistenceRepository<UserProfile, Guid>
    {
    }
}
