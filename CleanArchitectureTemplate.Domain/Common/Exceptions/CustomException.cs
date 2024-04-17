using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
    public class CustomException : Exception
    {
        public string UserFriendlyMessage { get; set; }
        public string DeveloperDetail { get; set; }
        public string Type { get; set; }
        public string ErrorCode { get; set; }
        public IDictionary<string, Dictionary<string, string>> Param { get; set; }
        public Exception? InnerCustomException { get; set; }

        public CustomException()
        {
        }

        public CustomException(
            string userFriendlyMessage,
            Exception? innerCustomException = null,
            string developerDetail = "",
            string type = "",
            string errorCode = "",
            IDictionary<string, Dictionary<string, string>>? param = null
            )
            : base(userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            DeveloperDetail = developerDetail;
            Type = type;
            ErrorCode = errorCode;
            Param = param;
            InnerCustomException = innerCustomException;

        }
        public virtual CustomException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public virtual CustomException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }
        public virtual CustomException WithMessage(string DefaultMessage, string LocalizedMessage)
        {
            WithDeveloperDetail(DefaultMessage);
            WithUserFriendlyMessage(LocalizedMessage);
            return this;
        }
        public virtual CustomException WithMessage(string DefaultMessage)
        {
            WithDeveloperDetail(DefaultMessage);
            WithUserFriendlyMessage(DefaultMessage);
            return this;
        }
        public virtual CustomException WithType(string type)
        {
            Type = type;
            return this;
        }
        public virtual CustomException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }
        public virtual CustomException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public virtual CustomException WithParam(IDictionary<string, Dictionary<string, string>> param)
        {
            Param = param;
            return this;
        }
    }
}
