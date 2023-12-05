using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class PasswordPatternException : CustomException
    {

        public PasswordPatternException()
           : base(string.Empty, null)
        {
        }

        public PasswordPatternException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public PasswordPatternException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public PasswordPatternException WithType(string type)
        {
            Type = type;
            return this;
        }

        public PasswordPatternException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public PasswordPatternException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public PasswordPatternException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}
