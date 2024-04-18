using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IActivityRepository :
        IReadableRepository<Activity, Guid>,
        IWritableRepository<Activity, Guid>,
        IPaginatedRepository<Activity>,
        IExistenceRepository<Activity, Guid>
    {

    }
}
