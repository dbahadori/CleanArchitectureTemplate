using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class DomainModelNotfoundException : CustomException
    {
        public DomainModelNotfoundException()
            : base(string.Empty, null)
        {
        }


        public DomainModelNotfoundException(string name,
            object key,
            string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"The specified \"{name}\" ({key}) was not found. Please ensure you have selected a valid \"{name}\" from the available options.";
        }
    }
}
