using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class ActivityRepository : BaseRepository<Activity, Guid>, IActivityRepository
    {
        public ActivityRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
