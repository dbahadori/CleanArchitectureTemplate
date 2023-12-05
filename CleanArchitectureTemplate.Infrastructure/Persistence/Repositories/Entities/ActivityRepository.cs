using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class ActivityRepository : BaseRepository<ActivityEntity, Guid>, IActivityRepository, IBaseRepository<ActivityEntity, Guid>
    {
        public ActivityRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

    }
}
