﻿using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Components.RecipeGenerators.MainCourse
{
    internal class RoastMainCourseRecipeGenerator : IMainCourseRecipeGenerator
    {
        private readonly IRecipeBuilder _recipeBuilder;
        private readonly IIngredientBuilder _ingredientBuilder;

        public RoastMainCourseRecipeGenerator(IRecipeBuilder recipeBuilder, IIngredientBuilder ingredientBuilder)
        {
            _recipeBuilder = recipeBuilder;
            _ingredientBuilder = ingredientBuilder;
        }

        public IRecipe Generate()
        {
            var beefRoast = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Tender beef roast")
                .WithName("Beef Roast")
                .WithQuantity(1000)
                .Build();

            var potatoes = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Large potatoes")
                .WithName("Potatoes")
                .WithQuantity(500)
                .Build();

            var carrots = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Fresh carrots")
                .WithName("Carrots")
                .WithQuantity(600)
                .Build();

            var onions = _ingredientBuilder
                .WithId(Guid.NewGuid())
                .WithDescription("Yellow onions")
                .WithName("Onions")
                .WithQuantity(1)
                .WithQuantityUnit(IngredientUnit.Piece)
                .Build();

            var recipe = _recipeBuilder
                .WithName("Classic Roast Beef")
                .WithCategory(RecipeCategory.MAIN_COURSE)
                .WithType(RecipeType.ROAST)
                .WithDescription("A delicious and tender roast beef recipe with flavorful roasted vegetables.")
                .AddIngredient(beefRoast)
                .AddIngredient(potatoes)
                .AddIngredient(carrots)
                .AddIngredient(onions)
                .WithCookingTime(TimeSpan.FromMinutes(120))
                .Build();

            return recipe;
        }
    }
}