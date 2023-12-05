using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
    public class InvalidPageSizePageIndexException : CustomException
    {


        public InvalidPageSizePageIndexException()
            : base(string.Empty, null)
        {
        }

        public InvalidPageSizePageIndexException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public InvalidPageSizePageIndexException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public InvalidPageSizePageIndexException WithType(string type)
        {
            Type = type;
            return this;
        }

        public InvalidPageSizePageIndexException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public InvalidPageSizePageIndexException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public InvalidPageSizePageIndexException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

    }
}
