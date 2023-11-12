using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators;
using CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories;
using CleanArchitectureReferenceTemplate.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Factories
{
    public class MainCourseTypesRecipeGeneratorFactory : IRecipeGeneratorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public MainCourseTypesRecipeGeneratorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRecipeGenerator CreateRecipeGenerator(RecipeType recipeType)
        {
            var recipeGenerator = _serviceProvider.GetKeyedService<IMainCourseRecipeGenerator>(recipeType);
            if (recipeGenerator != null)
                return recipeGenerator;
            throw new ArgumentException("Invalid Recipe type.");
        }
    }
}
