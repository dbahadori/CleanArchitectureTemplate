using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Factories
{
    public class RecipeGeneratorFactoryProvider : IRecipeGeneratorFactoryProvider
    {
        private readonly IServiceProvider _serviceProvider;


        public RecipeGeneratorFactoryProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IRecipeGeneratorFactory GetFactory(RecipeCategory category)
        {
            var factory = _serviceProvider.GetKeyedService<IRecipeGeneratorFactory>(category);
            if(factory!=null)
                return factory;
            throw new ArgumentException("Invalid Recipe category.");
        }
    }
}
