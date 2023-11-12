using CleanArchitectureReferenceTemplate.Domain.Common.Validations;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Domain.Enums;

namespace CleanArchitectureReferenceTemplate.Domain.Models
{
    public class Recipe: IRecipe
    {
        private readonly IModelValidator _modelValidator;
        public Recipe(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;
            Ingredients = new List<Ingredient>();

        }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();

        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Instructions { get; set; }
        public string? Description { get; set; }
        public IList<Ingredient> Ingredients { get; private set; }
        public TimeSpan CookingTime { get; set; }
        public RecipeType Type { get; set; }
        public RecipeCategory Category { get; set; }

        public Recipe AddIngredient(Ingredient ingredient)
        {
            _modelValidator.ValidateAndThrow(ingredient);
            ingredient.RecipeId = this.Id;
            this.Ingredients.Add(ingredient);
            return this;
        }
        public Recipe AddIngredients(IList<Ingredient> ingredients)
        {
            _modelValidator.ValidateAndThrow(ingredients);
            foreach (var ingredient in ingredients)
                this.AddIngredient(ingredient);
            return this;
        }
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Name}: {ingredient.Quantity} {ingredient.Unit}");
            }
            Console.WriteLine("Instructions:");
            Console.WriteLine(Instructions);
            Console.WriteLine($"Cooking Time: {CookingTime.TotalMinutes} minutes");
        }
        public Recipe ClearIngredients()
        {
            this.Ingredients.Clear();
            return this;
        }
    }
}