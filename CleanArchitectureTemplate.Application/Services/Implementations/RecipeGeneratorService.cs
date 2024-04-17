using CleanArchitectureTemplate.Application.Common.Interfaces;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Application.Services.Interfaces;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;


namespace CleanArchitectureTemplate.Application.Services.Implementations
{
    public class RecipeGeneratorService : IRecipeGeneratorService
    {
        private readonly IRecipeGeneratorFactoryProvider _recipeGeneratorFactoryProvider;
        public RecipeGeneratorService(IRecipeGeneratorFactoryProvider recipeGeneratorFactoryProvider)
        {
            _recipeGeneratorFactoryProvider = recipeGeneratorFactoryProvider;
        }

        public Recipe Generate(RecipeType recipeType, RecipeCategory recipeCategory)
        {
            try
            {
                var factory = _recipeGeneratorFactoryProvider.GetFactory(recipeCategory);
                var generator = factory.CreateRecipeGenerator(recipeType);
                var recipe = generator.Generate();

                return recipe;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}


