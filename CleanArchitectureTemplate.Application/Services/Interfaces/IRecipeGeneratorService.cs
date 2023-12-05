using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface IRecipeGeneratorService
    {
        IRecipe Generate(RecipeType recipeType, RecipeCategory recipeCategory);
    }
}