using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class ExistEmailException : Exception
    {

        public ExistEmailException()
            : base()
        {
        }

        public ExistEmailException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;
        }

        public ExistEmailException(string email, string localizedMessage)
            : base($"This Email : \"{email}\" was found. Can't create new user with this Email address.")
        {
            Data["LocalizedMessage"] = localizedMessage;

        }
    }
}
