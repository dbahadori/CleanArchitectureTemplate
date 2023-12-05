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
        public IDictionary<string, string[]> Param { get; set; }
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
            IDictionary<string, string[]>? param = null
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

    }
}
