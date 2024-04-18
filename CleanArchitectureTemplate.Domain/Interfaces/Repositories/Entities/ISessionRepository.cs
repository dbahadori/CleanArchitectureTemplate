using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ISessionRepository :
        IReadableRepository<Session, Guid>,
        IWritableRepository<Session, Guid>,
        IPaginatedRepository<Session>,
        IExistenceRepository<Session, Guid>
    {
    }
}
