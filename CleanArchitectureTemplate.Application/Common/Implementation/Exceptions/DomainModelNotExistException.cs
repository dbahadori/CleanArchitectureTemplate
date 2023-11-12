using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class DomainModelNotExistException : Exception
    {
        public string? PersianMessage => Data["LocalizedMessage"]?.ToString();

        public DomainModelNotExistException()
            : base()
        {

        }
        public DomainModelNotExistException(string message, string localizedMessage)
            : base(message)
        {
            base.
            Data["LocalizedMessage"] = localizedMessage;
        }

        public DomainModelNotExistException(string message, Exception innerException, string localizedMessage)
            : base(message, innerException)
        {
            Data["LocalizedMessage"] = localizedMessage;
        }

        public DomainModelNotExistException(string name, object key, string localizedMessage)
            : base($"The specified \"{name}\" ({key}) was not found. Please ensure you have selected a valid \"{name}\" from the available options.")
        {
            Data["LocalizedMessage"] = localizedMessage;
        }
    }
}
