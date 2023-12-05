using CleanArchitectureTemplate.Domain.Entities;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IBookmarkRepository : IBaseRepository<BookmarkEntity, Guid>
    {
    }
}
