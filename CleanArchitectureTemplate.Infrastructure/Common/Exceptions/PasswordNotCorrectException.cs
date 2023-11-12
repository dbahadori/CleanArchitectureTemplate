namespace CleanArchitectureReferenceTemplate.Infrastructure.Common.Exceptions;

public class PasswordNotCorrectException : Exception
{
    public PasswordNotCorrectException()
        : base()
    {
    }

    public PasswordNotCorrectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public PasswordNotCorrectException(string email)
        : base($"Password not correct for user : {email}")
    {
    }
}
