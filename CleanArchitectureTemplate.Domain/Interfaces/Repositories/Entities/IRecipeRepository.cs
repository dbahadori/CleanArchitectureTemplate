using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Domain.ValueObejects;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IRecipeRepository : IBaseRepository<Recipe, Guid>
    {

    }
}
