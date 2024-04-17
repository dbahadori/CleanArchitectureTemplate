using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Infrastructure.Common.Exceptions;

public class PasswordNotCorrectException : CustomException
{

    public PasswordNotCorrectException()
    : base(string.Empty, null)
    {
    }

    public PasswordNotCorrectException(string email, string userFriendlyMessage)
        : base(userFriendlyMessage)
    {
        DeveloperDetail = $"Password not correct for user : {email}";
    }
}
