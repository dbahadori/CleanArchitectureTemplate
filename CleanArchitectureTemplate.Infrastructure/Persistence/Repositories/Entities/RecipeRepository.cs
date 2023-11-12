using AutoMapper;
using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureReferenceTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class RecipeRepository : BaseRepository<RecipeEntity, Guid>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
