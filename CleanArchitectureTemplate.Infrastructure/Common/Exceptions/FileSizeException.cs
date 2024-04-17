using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileSizeException : CustomException
{

    public FileSizeException()
        : base(string.Empty, null)
    {
    }

}
