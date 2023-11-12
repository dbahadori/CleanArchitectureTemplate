using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureReferenceTemplate.Application.Common.Implementation.Exceptions
{
    public class NullRepositoryException : Exception
    {
        public NullRepositoryException()
    : base()
        {
        }

        public NullRepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public NullRepositoryException(string name)
            : base($"Repository {name} not found")
        {
        }
    }
}
