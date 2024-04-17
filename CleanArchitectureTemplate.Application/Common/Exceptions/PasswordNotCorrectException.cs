using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class PasswordNotCorrectException : CustomException
    {

        public PasswordNotCorrectException()
            : base(string.Empty, null)
        {
        }


    }
}
