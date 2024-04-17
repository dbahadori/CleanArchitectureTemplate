using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class NotFoundUserException : CustomException
    {

        public NotFoundUserException()
            : base(string.Empty, null)
        {
        }


        public NotFoundUserException(string name, object key, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"Entity \"{name}\" ({key}) was not found.";

        }
    }
}
