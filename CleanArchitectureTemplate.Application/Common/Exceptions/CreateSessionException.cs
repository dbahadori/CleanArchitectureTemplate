using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    [Serializable]
    public class CreateSessionException : CustomException
    {

        public CreateSessionException()
            : base(string.Empty, null)
        {
        }


        public CreateSessionException(string userId)
            : base($"Create Session for User \"{userId}\" Has Error.")
        {
        }
    }
}

