using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class EntityRetrievalException : CustomException
    {
        public EntityRetrievalException()
    : base(string.Empty, null)
        {
        }
    }
}
