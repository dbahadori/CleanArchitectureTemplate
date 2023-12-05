using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Models;


namespace CleanArchitectureTemplate.Application.Common.Interfaces.Builders
{
    public interface IIngredientBuilder
    {
        IIngredientBuilder WithId(Guid id);
        IIngredientBuilder WithName(string name);
        IIngredientBuilder WithDescription(string description);
        IIngredientBuilder WithQuantityUnit(IngredientUnit unit);
        IIngredientBuilder WithQuantity(double quantity);


        Ingredient Build();
    }
}
