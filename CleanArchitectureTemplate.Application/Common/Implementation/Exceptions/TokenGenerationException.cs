using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitectureTemplate.Domain.Common.Exceptions;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class TokenGenerationException : CustomException
    {

        public TokenGenerationException()
     : base(string.Empty, null)
        {
        }

        public TokenGenerationException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public TokenGenerationException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public TokenGenerationException WithType(string type)
        {
            Type = type;
            return this;
        }

        public TokenGenerationException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public TokenGenerationException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public TokenGenerationException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}

