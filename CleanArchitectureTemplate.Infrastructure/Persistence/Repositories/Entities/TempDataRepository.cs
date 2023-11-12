using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class TempDataRepository : BaseRepository<TempDataEntity, Guid>, ITempDataRepository
    {
        public TempDataRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
