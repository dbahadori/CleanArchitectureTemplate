using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Domain.Entities
{
    public class Ingredient : AuditableEntity
    {
        private readonly IModelValidator _modelValidator;

        public Ingredient(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;

        }
        public Ingredient()
        {
        }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
        public double Quantity { get; set; } = 0;
        public IngredientUnit Unit { get; set; } = IngredientUnit.Gram;
        public Guid? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }


    }

}