using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileSizeException : CustomException
{

    public FileSizeException()
        : base(string.Empty, null)
    {
    }

    public FileSizeException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public FileSizeException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public FileSizeException WithType(string type)
    {
        Type = type;
        return this;
    }

    public FileSizeException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public FileSizeException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public FileSizeException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }
}
