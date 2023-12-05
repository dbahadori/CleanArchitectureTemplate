using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class SaveMediaInHostException : CustomException
    {

        public SaveMediaInHostException()
            : base(string.Empty, null)
        {
        }

        public SaveMediaInHostException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public SaveMediaInHostException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public SaveMediaInHostException WithType(string type)
        {
            Type = type;
            return this;
        }

        public SaveMediaInHostException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public SaveMediaInHostException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public SaveMediaInHostException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}
