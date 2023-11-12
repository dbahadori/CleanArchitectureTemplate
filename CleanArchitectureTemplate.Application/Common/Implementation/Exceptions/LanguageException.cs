using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class LanguageException : Exception
    {

        public LanguageException()
            : base()
        {

        }

        public LanguageException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public LanguageException(string message, string localizedMessage)
            : base(message)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }
    }
}
