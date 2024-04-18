using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Domain.ValueObejects;
using Ticketing.Domain.Interfaces.Repositories;

namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IRecipeRepository :
        IReadableRepository<Recipe, Guid>,
        IWritableRepository<Recipe, Guid>,
        IPaginatedRepository<Recipe>,
        IExistenceRepository<Recipe, Guid>
    {

    }
}
