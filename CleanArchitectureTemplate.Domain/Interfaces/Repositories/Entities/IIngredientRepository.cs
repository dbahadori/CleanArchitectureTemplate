using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Domain.ValueObejects;


namespace CleanArchitectureTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IIngredientRepository : IBaseRepository<IngredientEntity , Guid>
    {
    }
}
