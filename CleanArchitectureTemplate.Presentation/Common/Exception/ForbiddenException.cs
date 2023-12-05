using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Presentation.Common.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException()
    : base(string.Empty, null)
    {
    }

    public ForbiddenException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public ForbiddenException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public ForbiddenException WithType(string type)
    {
        Type = type;
        return this;
    }

    public ForbiddenException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public ForbiddenException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public ForbiddenException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }

    public ForbiddenException(string resourceName, object key)
        : base()
    {
    }
}
