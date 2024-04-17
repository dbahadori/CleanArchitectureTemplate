using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class FileTemplateException : CustomException
{

    public FileTemplateException()
        : base(string.Empty, null)
    {
    }

}
