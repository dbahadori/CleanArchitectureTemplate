using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class UserCreationException : Exception
    {
        public UserCreationException()
    : base()
        {
        }

        public UserCreationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public UserCreationException(string email)
            : base($"Error in Create user with this email : {email}")
        {
        }
    }
}
