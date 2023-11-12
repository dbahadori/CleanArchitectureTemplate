using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class PasswordPatternException : Exception
    {

        public PasswordPatternException()
            : base()
        {

        }

        public PasswordPatternException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public PasswordPatternException(string message, string localizedMessage)
            : base(message)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }
    }
}
