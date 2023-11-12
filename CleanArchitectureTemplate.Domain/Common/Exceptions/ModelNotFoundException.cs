using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Domain.Common.Exceptions
{
    public class ModelNotFoundException : Exception
    {

        public ModelNotFoundException()
            : base()
        {

        }

        public ModelNotFoundException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }

        public ModelNotFoundException(string message, string localizedMessage)
            : base(message)
        {
            Data["LocalizedMessage"] = localizedMessage;

        }
    }
}
