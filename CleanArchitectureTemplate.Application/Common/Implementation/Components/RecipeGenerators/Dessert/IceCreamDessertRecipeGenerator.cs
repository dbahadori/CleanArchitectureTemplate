using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.Dessert
{
    internal class IceCreamDessertRecipeGenerator : IDessertRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public IceCreamDessertRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public IRecipe Generate()
        {
            var heavyCream = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Heavy cream")
                .WithName("Heavy Cream")
                .WithQuantity(500)
                .WithQuantityUnit(IngredientUnit.Milliliter)
                .Build();

            var sugar = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Sugar")
                .WithName("Sugar")
                .WithQuantity(150)
                .WithQuantityUnit(IngredientUnit.Gram)
                .Build();

            var vanillaExtract = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Vanilla extract")
                .WithName("Vanilla Extract")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Teaspoon)
                .Build();

            var eggs = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Eggs")
                .WithName("Eggs")
                .WithQuantity(4)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Vanilla Ice Cream")
                .WithCategory(RecipeCategory.DESSERT)
                .WithType(RecipeType.ICE_CREAM)
                .WithDescription("Creamy homemade vanilla ice cream.")
                .AddIngredient(heavyCream)
                .AddIngredient(sugar)
                .AddIngredient(vanillaExtract)
                .AddIngredient(eggs)
                .WithCookingTime(TimeSpan.FromMinutes(15))
                .Build();

            return recipe;
        }
    }
}