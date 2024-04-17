using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Breakfast
{
    public class OmeletteGenerator : IBreakfastRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public OmeletteGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public Recipe Generate()
        {
            var eggs = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Fresh eggs")
                .WithName("Eggs")
                .WithQuantity(3)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var cheese = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Shredded cheese")
                .WithName("Cheese")
                .WithQuantity(0.5)
                .WithQuantityUnit(IngredientUnit.Cup)
                .Build();

            var vegetables = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Assorted vegetables (e.g., bell peppers, onions, mushrooms)")
                .WithName("Assorted Vegetables")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Cup)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Vegetable Omelette")
                .WithCategory(RecipeCategory.BREAKFAST)
                .WithType(RecipeType.OMELETTE)
                .WithDescription("A delicious and healthy vegetable omelette.")
                .AddIngredient(eggs)
                .AddIngredient(cheese)
                .AddIngredient(vegetables)
                .WithCookingTime(TimeSpan.FromMinutes(15))
                .Build();

            return recipe;
        }
    }
}