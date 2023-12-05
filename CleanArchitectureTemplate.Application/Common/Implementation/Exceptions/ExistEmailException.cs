using CleanArchitectureTemplate.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc.Versioning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Common.Implementation.Exceptions
{
    public class ExistEmailException : CustomException
    {

        public ExistEmailException()
            : base(string.Empty, null)
        {
        }

        public ExistEmailException WithUserFriendlyMessage(string userFriendlyMessage)
        {
            UserFriendlyMessage = userFriendlyMessage;
            return this;
        }

        public ExistEmailException WithDeveloperDetail(string developerDetail)
        {
            DeveloperDetail = developerDetail;
            return this;
        }

        public ExistEmailException WithType(string type)
        {
            Type = type;
            return this;
        }

        public ExistEmailException WithErrorCode(string errorCode)
        {
            ErrorCode = errorCode;
            return this;
        }

        public ExistEmailException WithInnerCustomException(Exception innerCustomException)
        {
            InnerCustomException = innerCustomException;
            return this;
        }

        public ExistEmailException WithParam(IDictionary<string, string[]> param)
        {
            Param = param;
            return this;
        }

        public ExistEmailException(string email, string? userFriendlyMessage)
            : base(userFriendlyMessage)
        {
             DeveloperDetail=$"This Email : \"{email}\" was found. Can't create new user with this Email address.";

        }
    }
}
