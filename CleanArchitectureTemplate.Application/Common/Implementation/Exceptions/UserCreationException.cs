using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class UserCreationException : CustomException
    {

        public UserCreationException()
            : base(string.Empty, null)
        {
        }

        public UserCreationException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public UserCreationException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public UserCreationException WithType(string type)
        {
            Type = type;
            return this;
        }

        public UserCreationException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public UserCreationException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public UserCreationException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

        public UserCreationException(string email, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"Error in Create user with this email : {email}";
        }

    }
}
