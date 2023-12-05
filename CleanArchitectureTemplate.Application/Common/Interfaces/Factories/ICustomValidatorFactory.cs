using FluentValidation;


namespace CleanArchitectureTemplate.Application.Common.Interfaces.Factories
{
    public interface ICustomValidatorFactory
    {
        IValidator<T> CreateValidator<T>();
    }
}
