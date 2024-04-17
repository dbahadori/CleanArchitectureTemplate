using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileExtentionException : CustomException
{

    public FileExtentionException()
        : base(string.Empty, null)
    {
    }

}
