using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Beverage
{
    public class SmoothieGenerator : IBeverageRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public SmoothieGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
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
                .WithCookingTime(TimeSpan.FromMinutes(10))
                .Build();

            return recipe;
        }
    }
}