using CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CleanArchitectureReferenceTemplate.Presentation.Filters
{
    public class Modelstatefeaturefilter : IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(ActionExecutingContext context, Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate next)
        {
            if (context.ModelState.IsValid == false)
            {
                var validationFailures = new List<ValidationFailure>();

                foreach (var entry in context.ModelState)
                {
                    if (entry.Value.Errors.Count > 0)
                    {
                        foreach (var error in entry.Value.Errors)
                        {
                            ValidationFailure validationFailure = new ValidationFailure(entry.Key, error.ErrorMessage);
                            validationFailures.Add(validationFailure);
                        }
                    }
                }

                throw new CustomValidationException(validationFailures);
            }
            var executedContext = await next();

        }
    }
}
