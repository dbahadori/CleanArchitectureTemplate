using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class BookmarkRepository : BaseRepository<BookmarkEntity, Guid>, IBookmarkRepository
    {
        public BookmarkRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
