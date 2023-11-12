using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;


namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class RoleRepository : BaseRepository<RoleEntity, Guid>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
