
namespace CleanArchitectureTemplate.Domain.Common.Exceptions;

public class NotFoundException : CustomException
{

    public NotFoundException()
        : base(string.Empty, null)
    {
    }

    public NotFoundException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public NotFoundException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public NotFoundException WithType(string type)
    {
        Type = type;
        return this;
    }

    public NotFoundException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public NotFoundException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public NotFoundException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }

    public NotFoundException(string resourceName, object key, string? userFriendlyMessage)
        : base(userFriendlyMessage)
    {
        DeveloperDetail = $"Resource \"{resourceName}\" ({key}) was not found.";
    }
}
