using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class NotFoundUserException : Exception
    {
        public NotFoundUserException()
    : base()
        {
        }

        public NotFoundUserException(string message)
            : base(message)
        {
        }

        public NotFoundUserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NotFoundUserException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}
