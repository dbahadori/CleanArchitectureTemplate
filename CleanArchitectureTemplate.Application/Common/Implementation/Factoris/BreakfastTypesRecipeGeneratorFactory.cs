using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Factories
{
    public class BreakfastTypesRecipeGeneratorFactory : IRecipeGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public BreakfastTypesRecipeGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRecipeGenerator CreateRecipeGenerator(RecipeType recipeType)
        {
            var recipeGenerator = _serviceProvider.GetKeyedService<IBreakfastRecipeGenerator>(recipeType);
            if (recipeGenerator != null)
                return recipeGenerator;
            throw new ArgumentException("Invalid Recipe type.");
        }
    }
}
