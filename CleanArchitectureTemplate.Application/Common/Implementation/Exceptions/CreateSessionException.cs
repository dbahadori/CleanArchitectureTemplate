using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class CreateSessionException : Exception
    {
        public CreateSessionException()
: base()
        {
        }

        public CreateSessionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public CreateSessionException(string userId)
            : base($"Create Session for User \"{userId}\" Has Error.")
        {
        }
    }
}

