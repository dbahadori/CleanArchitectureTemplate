using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface ITempDataRepository :
        IReadableRepository<TempData, Guid>,
        IWritableRepository<TempData, Guid>,
        IPaginatedRepository<TempData>,
        IExistenceRepository<TempData, Guid>
    {
    }
}
