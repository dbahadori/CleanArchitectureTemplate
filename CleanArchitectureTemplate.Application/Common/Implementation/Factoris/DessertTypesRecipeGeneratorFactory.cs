using CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureTemplate.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Factories
{
    public class DessertTypesRecipeGeneratorFactory : IRecipeGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public DessertTypesRecipeGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRecipeGenerator CreateRecipeGenerator(RecipeType recipeType)
        {
            var recipeGenerator = _serviceProvider.GetKeyedService<IDessertRecipeGenerator>(recipeType);
            if (recipeGenerator != null)
                return recipeGenerator;
            throw new ArgumentException("Invalid Recipe type.");
        }
    }
}
