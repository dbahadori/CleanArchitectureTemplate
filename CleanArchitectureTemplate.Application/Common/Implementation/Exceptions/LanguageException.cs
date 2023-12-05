using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class LanguageException : CustomException
    {
        public LanguageException()
            : base(string.Empty, null)
        {
        }

        public LanguageException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public LanguageException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public LanguageException WithType(string type)
        {
            Type = type;
            return this;
        }

        public LanguageException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public LanguageException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public LanguageException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}
