using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class ActivityRepository : BaseRepository<ActivityEntity, Guid>, IActivityRepository, IBaseRepository<ActivityEntity, Guid>
    {
        public ActivityRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
