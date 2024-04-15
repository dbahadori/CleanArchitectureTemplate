using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Enums;


namespace CleanArchitectureTemplate.Application.Common.Interfaces.Builders
{
    public interface IRecipeBuilder
    {
        IRecipeBuilder WithName(string name);
        IRecipeBuilder WithDescription(string description);
        IRecipeBuilder WithInstructions(string instructions);
        IRecipeBuilder WithCookingTime(TimeSpan cookingTime);
        IRecipeBuilder WithType(RecipeType type);
        IRecipeBuilder WithCategory(RecipeCategory category);
        IRecipeBuilder AddIngredient(Ingredient ingredient);
        IRecipeBuilder AddIngredients(IList<Ingredient> ingredients);
        Recipe Build();
    }
}
