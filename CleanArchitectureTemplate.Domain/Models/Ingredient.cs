using CleanArchitectureReferenceTemplate.Domain.Common.Validations;
using CleanArchitectureReferenceTemplate.Domain.Enums;

namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class Ingredient
    {
        private readonly IModelValidator _modelValidator;

        public Ingredient(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;

        }
        public Ingredient()
        {
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; } =string.Empty;
        public double Quantity { get; set; } = 0;
        public IngredientUnit Unit { get; set; } = IngredientUnit.Gram;
        public Guid? RecipeId { get; set; }
        public Recipe? Recipe { get; set; }


    }

}