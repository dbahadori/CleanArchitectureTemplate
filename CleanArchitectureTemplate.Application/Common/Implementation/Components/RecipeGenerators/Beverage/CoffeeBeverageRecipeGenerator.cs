using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Beverage
{
    internal class CoffeeBeverageRecipeGenerator : IBeverageRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public CoffeeBeverageRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public IRecipe Generate()
        {
            var coffee = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Ground coffee")
                .WithName("Coffee")
                .WithQuantity(2)
                .WithQuantityUnit(IngredientUnit.Tablespoon)
                .Build();

            var water = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Water")
                .WithName("Water")
                .WithQuantity(250)
                .WithQuantityUnit(IngredientUnit.Milliliter)
                .Build();

            var sugar = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Sugar")
                .WithName("Sugar")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Teaspoon)
                .Build();

            var milk = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Milk")
                .WithName("Milk")
                .WithQuantity(100)
                .WithQuantityUnit(IngredientUnit.Milliliter)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Classic Coffee")
                .WithCategory(RecipeCategory.BEVERAGE)
                .WithType(RecipeType.COFFEE)
                .WithDescription("A classic cup of coffee.")
                .AddIngredient(coffee)
                .AddIngredient(water)
                .AddIngredient(sugar)
                .AddIngredient(milk)
                .Build();

            return recipe;
        }
    }
}