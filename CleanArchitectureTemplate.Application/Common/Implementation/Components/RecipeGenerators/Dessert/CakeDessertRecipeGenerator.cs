using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.Dessert
{
    internal class CakeDessertRecipeGenerator : IDessertRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public CakeDessertRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
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
                .WithQuantity(250)
                .WithQuantityUnit(IngredientUnit.Gram)
                .Build();

            var sugar = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Sugar")
                .WithName("Sugar")
                .WithQuantity(200)
                .WithQuantityUnit(IngredientUnit.Gram)
                .Build();

            var butter = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Unsalted butter")
                .WithName("Butter")
                .WithQuantity(200)
                .WithQuantityUnit(IngredientUnit.Gram)
                .Build();

            var eggs = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Eggs")
                .WithName("Eggs")
                .WithQuantity(4)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var bakingPowder = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Baking powder")
                .WithName("Baking Powder")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Teaspoon)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Classic Vanilla Cake")
                .WithCategory(RecipeCategory.DESSERT)
                .WithType(RecipeType.CAKE)
                .WithDescription("A delicious classic vanilla cake.")
                .AddIngredient(flour)
                .AddIngredient(sugar)
                .AddIngredient(butter)
                .AddIngredient(eggs)
                .AddIngredient(bakingPowder)
                .Build();

            return recipe;
        }
    }
}