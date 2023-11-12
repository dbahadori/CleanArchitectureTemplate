using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class SaveMediaInHostException : Exception
    {

        public SaveMediaInHostException()
            : base()
        {

        }
        public SaveMediaInHostException(string message)
: base(message)
        {

        }
        public SaveMediaInHostException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public SaveMediaInHostException(string message, string localizedMessage)
            : base(message)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }
    }
}
