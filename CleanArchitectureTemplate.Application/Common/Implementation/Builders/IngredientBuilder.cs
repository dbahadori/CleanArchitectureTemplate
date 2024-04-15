using CleanArchitectureTemplate.Domain.Enums;
using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Application.Common.Interfaces.Builders;
using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Builders
{
    public class IngredientBuilder : IIngredientBuilder
    {
        private Guid _id;
        private string _name = string.Empty;
        private string? _description;
        private double _quantity;
        private IngredientUnit _unit;
        private readonly IModelValidator _modelValidator;


        public IngredientBuilder(IModelValidator modelValidator)
        {
            _modelValidator = modelValidator;

            InitializeProperties();
        }

        public IIngredientBuilder WithId(Guid id)
        {
            _id = id;
            return this;
        }
        public IIngredientBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
        public IIngredientBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }
        public IIngredientBuilder WithQuantityUnit(IngredientUnit unit)
        {
            _unit = unit;
            return this;
        }

        public IIngredientBuilder WithQuantity(double quantity)
        {
            _quantity = quantity;
            return this;
        }

        public Ingredient Build()
        {
            var ingredient = new Ingredient(_modelValidator)
            {
                Description = _description,
                Id = _id,
                Quantity = _quantity,
                Unit = _unit,
                Name = _name
            };
            _modelValidator.ValidateAndThrow(ingredient);
            InitializeProperties();
            return ingredient;
        }
        private void InitializeProperties()
        {
            _name = string.Empty;
            _description = string.Empty;
            _unit = IngredientUnit.Gram;
            _quantity = 0;

        }


    }
}
