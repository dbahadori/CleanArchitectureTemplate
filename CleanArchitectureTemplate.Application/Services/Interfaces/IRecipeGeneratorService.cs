using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Interfaces.Models;

namespace CleanArchitectureTemplate.Application.Services.Interfaces
{
    public interface IRecipeGeneratorService
    {
        Recipe Generate(RecipeType recipeType, RecipeCategory recipeCategory);
    }
}