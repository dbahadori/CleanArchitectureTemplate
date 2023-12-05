using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Resources
{
    public static class ResourceHelper
    {
        public static (string DefaultMessage, string LocalizedMessage) GetErrorMessages(Expression<Func<ErrorMessages, string>> keySelector, params object[] args)
        {
            var resourceManager = new ResourceManager(typeof(ErrorMessages));

            var key = GetKeyFromExpression(keySelector);
            var defaultMessage = string.Format(resourceManager.GetString(key), args);
            var localizedMessage = string.Format(resourceManager.GetString(key, CultureInfo.CurrentCulture), args) ?? defaultMessage;

            return (defaultMessage, localizedMessage);
        }

        private static string GetKeyFromExpression(Expression<Func<ErrorMessages, string>> keySelector)
        {
            if (keySelector.Body is MemberExpression memberExpression &&
                memberExpression.Member is PropertyInfo propertyInfo)
            {
                return propertyInfo.Name;
            }

            throw new ArgumentException("Invalid key selector expression.");
        }
    }
}
