using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Presentation.Common.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException()
    : base(string.Empty, null)
    {
    }

    public ForbiddenException(string resourceName, object key)
        : base()
    {
    }
}
