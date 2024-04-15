using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Domain.Models
{
    public class Recipe: IRecipe
    {
        private readonly IModelValidator _modelValidator;
        public Recipe(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;
            _ingredients = new List<Ingredient>();

        }

        public Recipe()
        {
            _ingredients = new List<Ingredient>();

        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Instructions { get; set; }
        public string? Description { get; set; }
        private readonly List<Ingredient> _ingredients;
        public IReadOnlyCollection<Ingredient> Ingredients => _ingredients.AsReadOnly();
        
        public TimeSpan CookingTime { get; set; }
        public RecipeType Type { get; set; }
        public RecipeCategory Category { get; set; }

        public Recipe AddIngredient(Ingredient ingredient)
        {
            _modelValidator.ValidateAndThrow(ingredient);
            ingredient.RecipeId = this.Id;
            this._ingredients.Add(ingredient);
            return this;
        }
        public Recipe AddIngredients(IList<Ingredient> ingredients)
        {
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
            this._ingredients.Clear();
            return this;
        }
    }
}