using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileExtentionException : CustomException
{

    public FileExtentionException()
        : base(string.Empty, null)
    {
    }

    public FileExtentionException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public FileExtentionException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public FileExtentionException WithType(string type)
    {
        Type = type;
        return this;
    }

    public FileExtentionException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public FileExtentionException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public FileExtentionException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }

}
