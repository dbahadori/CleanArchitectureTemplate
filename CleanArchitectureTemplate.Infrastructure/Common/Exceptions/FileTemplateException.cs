namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;

public class FileTemplateException : Exception
{
    public FileTemplateException()
        : base()
    {
    }

    public FileTemplateException(string message, string localizedMessage)
        : base(message)
    {
        Data["LocalizedMessage"] = localizedMessage;

    }
}
