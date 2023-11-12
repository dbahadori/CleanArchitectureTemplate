using CleanArchitectureReferenceTemplate.Domain.Entities;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IBookmarkRepository : IBaseRepository<BookmarkEntity, Guid>
    {
    }
}
