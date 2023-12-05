using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
    public class ModelNotFoundException : CustomException
    {

        public ModelNotFoundException()
            : base(string.Empty, null)
        {
        }

        public ModelNotFoundException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public ModelNotFoundException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public ModelNotFoundException WithType(string type)
        {
            Type = type;
            return this;
        }

        public ModelNotFoundException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public ModelNotFoundException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public ModelNotFoundException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }
    }
}
