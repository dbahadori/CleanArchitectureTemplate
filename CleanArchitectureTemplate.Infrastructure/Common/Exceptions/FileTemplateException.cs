using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileTemplateException : CustomException
{

    public FileTemplateException()
        : base(string.Empty, null)
    {
    }

    public FileTemplateException WithUserFriendlyMessage(string userFriendlyMessage)
    {
        UserFriendlyMessage = userFriendlyMessage;
        return this;
    }

    public FileTemplateException WithDeveloperDetail(string developerDetail)
    {
        DeveloperDetail = developerDetail;
        return this;
    }

    public FileTemplateException WithType(string type)
    {
        Type = type;
        return this;
    }

    public FileTemplateException WithErrorCode(string errorCode)
    {
        ErrorCode = errorCode;
        return this;
    }

    public FileTemplateException WithInnerCustomException(Exception innerCustomException)
    {
        InnerCustomException = innerCustomException;
        return this;
    }

    public FileTemplateException WithParam(IDictionary<string, string[]> param)
    {
        Param = param;
        return this;
    }
}
