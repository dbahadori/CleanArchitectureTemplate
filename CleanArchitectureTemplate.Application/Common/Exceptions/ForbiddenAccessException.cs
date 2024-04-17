using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System.Runtime.CompilerServices;

namespace CleanArchitectureTemplate.Application.Common.Exceptions;

public class ForbiddenAccessException : CustomException
{

    public ForbiddenAccessException()
        : base(string.Empty, null)
    {
    }


}
