using FluentValidation;
using System.Reflection;
using CleanArchitectureTemplate.Application.Common.Interfaces.Factories;

namespace CleanArchitectureTemplate.Infrastructure.CrossCutting.Validation
{
    public class FluentValidatorFactory : ICustomValidatorFactory
    {
        public IValidator<T> CreateValidator<T>()
        {

            var validatorType = typeof(AbstractValidator<>).MakeGenericType(typeof(T));

            // Make sure to get the concrete validator type, not the abstract base class
            var concreteValidatorType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.IsSubclassOf(validatorType) && !t.IsAbstract);

            if (concreteValidatorType != null)
            {
                var validatorInstance = Activator.CreateInstance(concreteValidatorType);
                if (validatorInstance != null)
                {
                    return (IValidator<T>)validatorInstance;
                }
                else
                {
                    throw new ArgumentException($"The specified Validator with name \"{typeof(T)}\" was not found.");
                }

            }
            else
            {
                // add log
                throw new ArgumentException($"The specified Validator with name \"{typeof(T)}\" was not found.");
            }
        }


    }
}
