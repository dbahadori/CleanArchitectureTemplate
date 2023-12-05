using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System.Runtime.CompilerServices;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions;

public class ForbiddenAccessException : CustomException
{

    public ForbiddenAccessException()
        : base(string.Empty, null)
    {
    }

    public ForbiddenAccessException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public ForbiddenAccessException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public ForbiddenAccessException WithType(string type)
    {
        Type = type;
        return this;
    }

    public ForbiddenAccessException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public ForbiddenAccessException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public ForbiddenAccessException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }
}
