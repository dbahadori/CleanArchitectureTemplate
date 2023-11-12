using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces;

namespace CleanArchitectureReferenceTemplate.Domain.Entities
{
    public class IngredientEntity : AuditableEntity
    {
        public IngredientEntity()
        {

        }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }= string.Empty;
        public double Quantity { get; set; } = 0;
        public IngredientUnit Unit { get; set; } = IngredientUnit.Gram;
        public required Guid RecipeId { get; set; }
        public RecipeEntity? Recipe { get; set; }



    }

}