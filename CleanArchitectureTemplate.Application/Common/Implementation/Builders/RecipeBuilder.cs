using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Models;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Builders
{
    public class RecipeBuilder : IRecipeBuilder
    {
        private string _name = string.Empty;
        private string? _description;
        private string? _instructions;
        private RecipeType _type;
        private RecipeCategory _category;

        private TimeSpan _cookingTime;
        private IList<Ingredient> _ingredients;
        private readonly IModelValidator _modelValidator;


        public RecipeBuilder(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;

            InitializeProperties();
        }
        public IRecipeBuilder AddIngredient(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
            return this;
        }
        public IRecipeBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public IRecipeBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        public IRecipeBuilder WithType(RecipeType type)
        {
            _type = type;
            return this;
        }
        public IRecipeBuilder WithCategory(RecipeCategory category)
        {
            _category = category;
            return this;
        }
        public IRecipeBuilder WithInstructions(string instructions)
        {
            _instructions = instructions;
            return this;
        }
        public IRecipeBuilder WithCookingTime(TimeSpan cookingTime)
        {
            _cookingTime = cookingTime;
            return this;
        }
        public IRecipeBuilder AddIngredients(IList<Ingredient> ingredients)
        {
            foreach (var ingredient in ingredients)
                AddIngredient(ingredient);
            return this;
        }
        public Recipe Build()
        {
            var recipe = new Recipe(_modelValidator)
            {
                Instructions = _instructions,
                Description = _description,
                Type = _type,
                Category = _category,
                Name = _name,
                CookingTime = _cookingTime
            };
            recipe.AddIngredients(_ingredients);
            _modelValidator.ValidateAndThrow(recipe);
            InitializeProperties();
            return recipe;
        }
        private void InitializeProperties()
        {
            _name = string.Empty;
            _description = string.Empty;
            _type = default;
            _cookingTime = TimeSpan.Zero;
            _description = string.Empty;
            _ingredients = new List<Ingredient>();

        }


    }
}
