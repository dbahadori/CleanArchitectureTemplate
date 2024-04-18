using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IRoleRepository :
        IReadableRepository<Role, Guid>,
        IWritableRepository<Role, Guid>,
        IPaginatedRepository<Role>,
        IExistenceRepository<Role, Guid>
    {
    }
}
