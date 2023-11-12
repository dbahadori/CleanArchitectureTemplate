using CleanArchitectureReferenceTemplate.Domain.Entities;
using CleanArchitectureReferenceTemplate.Domain.Models;
using CleanArchitectureReferenceTemplate.Domain.ValueObejects;


namespace CleanArchitectureReferenceTemplate.Domain.Interfaces.Repositories.Entities
{
    public interface IIngredientRepository : IBaseRepository<IngredientEntity , Guid>
    {
    }
}
