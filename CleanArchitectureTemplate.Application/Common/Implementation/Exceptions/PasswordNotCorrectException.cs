using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class PasswordNotCorrectException : CustomException
    {

        public PasswordNotCorrectException()
            : base(string.Empty, null)
        {
        }

        public PasswordNotCorrectException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public PasswordNotCorrectException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public PasswordNotCorrectException WithType(string type)
        {
            Type = type;
            return this;
        }

        public PasswordNotCorrectException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public PasswordNotCorrectException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public PasswordNotCorrectException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}
