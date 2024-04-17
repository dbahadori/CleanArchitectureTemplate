using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class TokenGenerationException : CustomException
    {

        public TokenGenerationException()
     : base(string.Empty, null)
        {
        }


    }
}

