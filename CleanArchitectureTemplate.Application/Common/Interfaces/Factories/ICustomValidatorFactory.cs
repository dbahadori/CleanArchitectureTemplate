using FluentValidation;


namespace CleanArchitectureReferenceTemplate.Application.Common.Interfaces.Factories
{
    public interface ICustomValidatorFactory
    {
        IValidator<T> CreateValidator<T>();
    }
}
