using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;


namespace CleanArchitectureTemplate.Application.Common.Interfaces.Components.RecipeGenerators
{
    public interface IRecipeGenerator
    {
        IRecipe Generate();
    }
}
