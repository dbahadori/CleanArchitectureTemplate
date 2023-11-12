using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class DomainModelNotFoundException : Exception
    {

        public DomainModelNotFoundException()
            : base()
        {

        }

        public DomainModelNotFoundException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public DomainModelNotFoundException(string message, string localizedMessage)
            : base(message)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public DomainModelNotFoundException(string message)
    : base(message)
        {
        }
    }
}
