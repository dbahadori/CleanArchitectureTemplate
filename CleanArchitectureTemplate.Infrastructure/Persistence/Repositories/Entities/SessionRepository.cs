using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class SessionRepository : BaseRepository<SessionEntity, Guid>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
