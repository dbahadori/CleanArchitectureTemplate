using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;


namespace CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Components.RecipeGenerators
{
    public interface IRecipeGenerator
    {
        IRecipe Generate();
    }
}
