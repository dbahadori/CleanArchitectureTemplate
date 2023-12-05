using CleanArchitectureTemplate.Domain.Common.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class NotFoundUserException : CustomException
    {

        public NotFoundUserException()
            : base(string.Empty, null)
        {
        }

        public NotFoundUserException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public NotFoundUserException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public NotFoundUserException WithType(string type)
        {
            Type = type;
            return this;
        }

        public NotFoundUserException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public NotFoundUserException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public NotFoundUserException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

        public NotFoundUserException(string name, object key, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
            DeveloperDetail = $"Entity \"{name}\" ({key}) was not found.";

        }
    }
}
