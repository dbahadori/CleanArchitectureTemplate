using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Components.RecipeGenerators.MainCourse
{
    public class Pasta_DishGenerator : IMainCourseRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public Pasta_DishGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public Recipe Generate()
        {
            var pasta = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Your favorite type of pasta")
                .WithName("Pasta")
                .WithQuantity(250)
                .Build();

            var sauce = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Tomato sauce")
                .WithName("Sauce")
                .WithQuantity(400)
                .Build();

            var meat = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Ground beef")
                .WithName("Beef")
                .WithQuantity(250)
                .Build();

            var onion = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Yellow onions")
                .WithName("Onion")
                .WithQuantity(200)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Classic Pasta Bolognese")
                .WithCategory(RecipeCategory.MAIN_COURSE)
                .WithType(RecipeType.PASTA_DISH)
                .WithDescription("A classic pasta dish with a rich Bolognese sauce.")
                .AddIngredient(pasta)
                .AddIngredient(sauce)
                .AddIngredient(meat)
                .AddIngredient(onion)
                .WithCookingTime(TimeSpan.FromMinutes(40))
                .Build();

            return recipe;
        }
    }
}