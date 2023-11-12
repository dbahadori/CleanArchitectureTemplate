namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;

public class FileSizeException : Exception
{
    public FileSizeException()
        : base()
    {
    }

    public FileSizeException(string message, string localizedMessage)
        : base(message)
    {
        Data["LocalizedMessage"] = localizedMessage;

    }
}
