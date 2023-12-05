using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    [Serializable]
    public class CreateSessionException : CustomException
    {

        public CreateSessionException()
            : base(string.Empty, null)
        {
        }

        public CreateSessionException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public CreateSessionException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public CreateSessionException WithType(string type)
        {
            Type = type;
            return this;
        }

        public CreateSessionException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public CreateSessionException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public CreateSessionException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

        public CreateSessionException(string userId)
            : base($"Create Session for User \"{userId}\" Has Error.")
        {
        }
    }
}

