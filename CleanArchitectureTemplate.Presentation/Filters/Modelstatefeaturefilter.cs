using CleanArchitectureTemplate.Application.Common.Exceptions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace CleanArchitectureTemplate.Presentation.Filters
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

                throw new CustomValidationException()
                    .WithUserFriendlyMessage("the format of request message is not correct")
                    .WithDeveloperDetail("The submitted data is not in the expected format. Please check your input.");
                
            }
            var executedContext = await next();

        }
    }
}
