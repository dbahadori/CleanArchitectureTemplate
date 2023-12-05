using CleanArchitectureTemplate.Domain.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class DomainModelNotfoundException : CustomException
    {
        public DomainModelNotfoundException()
            : base(string.Empty, null)
        {
        }

        public DomainModelNotfoundException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public DomainModelNotfoundException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public DomainModelNotfoundException WithType(string type)
        {
            Type = type;
            return this;
        }

        public DomainModelNotfoundException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public DomainModelNotfoundException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public DomainModelNotfoundException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

        public DomainModelNotfoundException(string name,
            object key,
            string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"The specified \"{name}\" ({key}) was not found. Please ensure you have selected a valid \"{name}\" from the available options.";
        }
    }
}
