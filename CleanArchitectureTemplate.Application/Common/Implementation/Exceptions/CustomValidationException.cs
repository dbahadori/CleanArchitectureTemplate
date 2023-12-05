using CleanArchitectureTemplate.Domain.Common.Exceptions;
using FluentValidation.Results;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions;

public class CustomValidationException : CustomException
{
    public CustomValidationException()
    : base("One or more validation failures have occurred.", null)
    {
    }
    public CustomValidationException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public CustomValidationException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public CustomValidationException WithType(string type)
    {
        Type = type;
        return this;
    }

    public CustomValidationException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public CustomValidationException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public CustomValidationException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }
    public CustomValidationException WithParam(IEnumerable<ValidationFailure> failures)
    {
        
        Param = failures
           .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
           .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray()); ;
        return this;
    }
}
