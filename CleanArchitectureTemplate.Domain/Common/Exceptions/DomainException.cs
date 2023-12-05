using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
    public class DomainException : Exception
    {
        protected DomainException(string message)
            : base(message)
        {
        }
    }
}
