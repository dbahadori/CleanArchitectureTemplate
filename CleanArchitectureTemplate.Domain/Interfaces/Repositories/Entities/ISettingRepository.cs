using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ISettingRepository :
        IReadableRepository<Setting, Guid>,
        IWritableRepository<Setting, Guid>,
        IPaginatedRepository<Setting>,
        IExistenceRepository<Setting, Guid>
    {
    }
}
