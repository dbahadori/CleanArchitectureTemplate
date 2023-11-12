using System.Runtime.CompilerServices;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions;

public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }
    public void SetData(string key, object value)
    {
        Data[key] = value;
    }

}
