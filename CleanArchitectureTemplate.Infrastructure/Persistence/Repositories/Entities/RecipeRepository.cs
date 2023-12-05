using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class RecipeRepository : BaseRepository<RecipeEntity, Guid>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
