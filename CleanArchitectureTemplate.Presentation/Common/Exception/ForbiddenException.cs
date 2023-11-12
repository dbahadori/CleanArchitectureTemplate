namespace CleanArchitectureReferenceTemplate.Presentation.Common.Exceptions;

public class ForbiddenException : Exception
{
    public ForbiddenException()
        : base()
    {
    }

    public ForbiddenException(string message)
        : base(message)
    {
    }

    public ForbiddenException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public ForbiddenException(string resourceName, object key)
        : base()
    {
    }
}
