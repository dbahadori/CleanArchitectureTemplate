using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class SessionRepository : BaseRepository<SessionEntity, Guid>, ISessionRepository
    {
        public SessionRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
