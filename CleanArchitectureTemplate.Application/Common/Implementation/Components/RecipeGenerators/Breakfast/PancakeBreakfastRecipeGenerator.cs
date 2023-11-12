using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Breakfast
{
    internal class PancakeBreakfastRecipeGenerator : IBreakfastRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public PancakeBreakfastRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public IRecipe Generate()
        {
            var flour = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("All-purpose flour")
                .WithName("Flour")
                .WithQuantity(1.5)
                .WithQuantityUnit(IngredientUnit.Cup)
                .Build();

            var milk = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Milk")
                .WithName("Milk")
                .WithQuantity(250)
                .WithQuantityUnit(IngredientUnit.Milliliter)
                .Build();

            var eggs = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Eggs")
                .WithName("Eggs")
                .WithQuantity(2)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var sugar = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Sugar")
                .WithName("Sugar")
                .WithQuantity(2)
                .WithQuantityUnit(IngredientUnit.Tablespoon)
                .Build();

            var bakingPowder = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Baking powder")
                .WithName("Baking Powder")
                .WithQuantity(2)
                .WithQuantityUnit(IngredientUnit.Teaspoon)
                .Build();

            var salt = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Salt")
                .WithName("Salt")
                .WithQuantity(0.5)
                .WithQuantityUnit(IngredientUnit.Teaspoon)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Classic Pancakes")
                .WithCategory(RecipeCategory.BREAKFAST)
                .WithType(RecipeType.PANCAKE)
                .WithDescription("Delicious and fluffy classic pancakes.")
                .AddIngredient(flour)
                .AddIngredient(milk)
                .AddIngredient(eggs)
                .AddIngredient(sugar)
                .AddIngredient(bakingPowder)
                .AddIngredient(salt)
                .WithCookingTime(TimeSpan.FromMinutes(20))
                .Build();

            return recipe;
        }
    }
}