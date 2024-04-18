using CleanArchitectureTemplate.Domain.Entities;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IBookmarkRepository :
        IReadableRepository<Bookmark, Guid>,
        IWritableRepository<Bookmark, Guid>,
        IPaginatedRepository<Bookmark>,
        IExistenceRepository<Bookmark, Guid>
    {
    }
}
