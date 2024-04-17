using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Exceptions
{
    public class UserCreationException : CustomException
    {

        public UserCreationException()
            : base(string.Empty, null)
        {
        }



        public UserCreationException(string email, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"Error in Create user with this email : {email}";
        }

    }
}
