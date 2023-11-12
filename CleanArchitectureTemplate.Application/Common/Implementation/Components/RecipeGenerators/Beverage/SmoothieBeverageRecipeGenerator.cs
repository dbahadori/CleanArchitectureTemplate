using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Beverage
{
    internal class SmoothieBeverageRecipeGenerator : IBeverageRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public SmoothieBeverageRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public IRecipe Generate()
        {
            var banana = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Ripe banana")
                .WithName("Banana")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var strawberry = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Fresh strawberries")
                .WithName("Strawberries")
                .WithQuantity(10)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var yogurt = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Yogurt")
                .WithName("Yogurt")
                .WithQuantity(150)
                .WithQuantityUnit(IngredientUnit.Milliliter)
                .Build();

            var honey = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Honey")
                .WithName("Honey")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Tablespoon)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Banana Strawberry Smoothie")
                .WithCategory(RecipeCategory.BEVERAGE)
                .WithType(RecipeType.SMOOTHIE)
                .WithDescription("A refreshing and creamy banana strawberry smoothie.")
                .AddIngredient(banana)
                .AddIngredient(strawberry)
                .AddIngredient(yogurt)
                .AddIngredient(honey)
                .Build();

            return recipe;
        }
    }
}