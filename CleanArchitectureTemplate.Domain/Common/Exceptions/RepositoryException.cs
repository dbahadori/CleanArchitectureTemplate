using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Domain.Common.Exceptions
{
        public class RepositoryException : CustomException
        {
            public RepositoryException()
                : base(string.Empty, null)
            {
            }

            public RepositoryException WithUserFriendlyMessage(string userFriendlyMessage)
            {
                UserFriendlyMessage = userFriendlyMessage;
                return this;
            }

            public RepositoryException WithDeveloperDetail(string developerDetail)
            {
                DeveloperDetail = developerDetail;
                return this;
            }

            public RepositoryException WithType(string type)
            {
                Type = type;
                return this;
            }

            public RepositoryException WithErrorCode(string errorCode)
            {
                ErrorCode = errorCode;
                return this;
            }

            public RepositoryException WithInnerCustomException(Exception innerCustomException)
            {
                InnerCustomException = innerCustomException;
                return this;
            }

            public RepositoryException WithParam(IDictionary<string, string[]> param)
            {
                Param = param;
                return this;
            }
        }
    }

