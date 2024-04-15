using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class SettingRepository : BaseRepository<Setting, Guid>, ISettingRepository
    {
        public SettingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
