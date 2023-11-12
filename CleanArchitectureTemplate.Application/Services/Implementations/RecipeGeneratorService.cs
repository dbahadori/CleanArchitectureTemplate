using CleanArchitectureReferenceTemplate.Application.Common.Interfaces;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureReferenceTemplate.Application.Services.Interfaces;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;


namespace CleanArchitectureReferenceTemplate.Application.Services.Implementations
{
    public class RecipeGeneratorService : IRecipeGeneratorService
    {
        private readonly IRecipeGeneratorFactoryProvider _recipeGeneratorFactoryProvider;
        public RecipeGeneratorService(IRecipeGeneratorFactoryProvider recipeGeneratorFactoryProvider)
        {
            _recipeGeneratorFactoryProvider = recipeGeneratorFactoryProvider;
        }

        public IRecipe Generate(RecipeType recipeType, RecipeCategory recipeCategory)
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


