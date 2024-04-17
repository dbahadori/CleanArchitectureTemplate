using CleanArchitectureTemplate.Domain.Common.Exceptions;
using FluentValidation.Results;
using CleanArchitectureTemplate.Resources;
using CleanArchitectureTemplate.Domain.Enums;

namespace CleanArchitectureTemplate.Application.Common.Exceptions;

public class CustomValidationException : CustomException
{
    public CustomValidationException()
    : base(ResourceHelper.GetErrorMessages<ValidationMessages>(e => ValidationMessages.ValidationErrorOccurred).LocalizedMessage, null)
    {
        ErrorCode = ErrorCodes.VALIDATION.ToString();
    }


    public CustomValidationException WithParam(IEnumerable<ValidationFailure> failures)
    {
        Param = failures
    .GroupBy(e => e.PropertyName)
    .ToDictionary(
        failureGroup => failureGroup.Key,
        failureGroup => failureGroup.ToDictionary(
            failure => "ErrorCode",
            failure => failure.ErrorCode,
            StringComparer.OrdinalIgnoreCase
        )
    );

        foreach (var failureGroup in failures.GroupBy(e => e.PropertyName))
        {
            foreach (var failure in failureGroup)
            {
                Param[failureGroup.Key].Add("ErrorMessage", failure.ErrorMessage);
            }
        }
        return this;
    }
}