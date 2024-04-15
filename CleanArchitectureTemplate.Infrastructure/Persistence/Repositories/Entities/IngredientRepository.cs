using AutoMapper;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities;
using CleanArchitectureTemplate.Infrastructure.Persistence.Context;

namespace CleanArchitectureTemplate.Infrastructure.Persistence.Repositories.Entities
{
    public class IngredientRepository : BaseRepository<Ingredient, Guid>, IIngredientRepository
    {
        public IngredientRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
