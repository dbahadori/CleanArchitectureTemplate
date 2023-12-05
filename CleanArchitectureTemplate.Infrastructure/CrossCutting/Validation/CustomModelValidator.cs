using FluentValidation;
using CleanArchitectureTemplate.Domain.Common.Validations;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation
{
    public class CustomModelValidator : IModelValidator
    {
        private readonly ICustomValidatorFactory _validatorFactory;
        public CustomModelValidator(ICustomValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }
        public bool Validate<T>(T model)
        {
            var validator = _validatorFactory.CreateValidator<T>();
            var validationResult = validator.Validate(model!);

            return validationResult.IsValid;
        }
        public void ValidateAndThrow<T>(T model)
        {
            var validator = _validatorFactory.CreateValidator<T>();
            validator.ValidateAndThrow(model);

        }
    }
}
