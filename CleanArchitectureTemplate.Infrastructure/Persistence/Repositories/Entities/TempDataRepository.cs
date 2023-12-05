using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class TempDataRepository : BaseRepository<TempDataEntity, Guid>, ITempDataRepository
    {
        public TempDataRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
