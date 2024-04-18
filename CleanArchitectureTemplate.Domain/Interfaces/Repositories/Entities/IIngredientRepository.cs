using CleanArchitectureTemplate.Domain.Entities;

using CleanArchitectureTemplate.Domain.ValueObejects;
using Ticketing.Domain.Interfaces.Repositories;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IIngredientRepository :
        IReadableRepository<Ingredient, Guid>,
        IWritableRepository<Ingredient, Guid>,
        IPaginatedRepository<Ingredient>,
        IExistenceRepository<Ingredient, Guid>
    {
    }
}
