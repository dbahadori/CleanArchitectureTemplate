using CleanArchitectureReferenceTemplate.Domain.Enums;
using CleanArchitectureReferenceTemplate.Domain.Interfaces.Models;

namespace CleanArchitectureReferenceTemplate.Application.Services.Interfaces
{
    public interface IRecipeGeneratorService
    {
        IRecipe Generate(RecipeType recipeType, RecipeCategory recipeCategory);
    }
}