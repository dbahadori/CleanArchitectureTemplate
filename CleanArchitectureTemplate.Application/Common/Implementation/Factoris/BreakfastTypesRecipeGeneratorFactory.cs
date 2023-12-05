using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;
using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Factories
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
