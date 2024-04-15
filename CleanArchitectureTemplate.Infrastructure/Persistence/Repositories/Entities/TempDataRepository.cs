using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class TempDataRepository : BaseRepository<TempData, Guid>, ITempDataRepository
    {
        public TempDataRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
