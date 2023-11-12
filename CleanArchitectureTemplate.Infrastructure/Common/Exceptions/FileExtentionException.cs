namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;

public class FileExtentionException : Exception
{
    public FileExtentionException()
        : base()
    {
    }

    public FileExtentionException(string message, string localizedMessage)
        : base(message)
    {
        Data["LocalizedMessage"] = localizedMessage;

    }
}
