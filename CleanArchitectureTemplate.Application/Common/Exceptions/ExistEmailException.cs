using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class ExistEmailException : CustomException
    {

        public ExistEmailException()
            : base(string.Empty, null)
        {
        }



        public ExistEmailException(string email, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"This Email : \"{email}\" was found. Can't create new user with this Email address.";

        }
    }
}
