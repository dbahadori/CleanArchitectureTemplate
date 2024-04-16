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
        private static CultureInfo _cultureInfo = CultureInfo.CurrentCulture;
        private static ResourceManager _entityResourceManager = new ResourceManager(typeof(EntityResource));

        public static (string DefaultMessage, string LocalizedMessage) GetGeneralErrorMessages(Expression<Func<ErrorMessages, string>> keySelector, params object[] args)
        {
            return GetErrorMessages(keySelector, args);
        }

        public static (string DefaultMessage, string LocalizedMessage) GetErrorMessages<TResource>(Expression<Func<TResource, string>> keySelector, params object[] args)
        {
          
            var resourceManager = new ResourceManager(typeof(TResource));
            var key = GetKeyFromExpression(keySelector);
            var (defArgs, localArgs) = GetArgumentValues(args);
            var usedLocalArgs = GetArgumentValues(localArgs, resourceManager.GetString(key, _cultureInfo));
            var defaultMessage = args.Length > 0 ? string.Format(resourceManager.GetString(key), defArgs) : resourceManager.GetString(key);
            var localizedMessage = usedLocalArgs.Length > 0 ? string.Format(resourceManager.GetString(key, _cultureInfo), usedLocalArgs) : resourceManager.GetString(key, _cultureInfo) ?? defaultMessage;

            return (defaultMessage, localizedMessage);
        }

        public static void SetCurrentCulture(CultureInfo cultureInfo)
        {
            _cultureInfo = cultureInfo;
        }

        public static string GetGeneralErrorMessageKey(Expression<Func<ErrorMessages, string>> keySelector)
        {
            return GetErrorMessageKey(keySelector);
        }
        public static string GetErrorMessageKey<TResource>(Expression<Func<TResource, string>> keySelector)
        {
            return GetKeyFromExpression(keySelector);
        }


        private static string GetKeyFromExpression<TResource>(Expression<Func<TResource, string>> keySelector)
        {
            if (keySelector.Body is MemberExpression memberExpression &&
                memberExpression.Member is PropertyInfo propertyInfo)
            {
                return propertyInfo.Name;
            }

            throw new ArgumentException("Invalid key selector expression.");
        }
        private static (object[], object[]) GetArgumentValues(object[] args)
        {
            // Replace each argument with its key and value from the EntityResource
            var argumentDefValues = new object[args.Length];
            var argumentLocalValues = new object[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                var argKey = args[i].ToString();
                var argDefaultValue = GetEntityName(argKey);
                var argLocalValue = GetEntityName(argKey, true);

                if (argDefaultValue == null || argLocalValue == null)
                    argumentDefValues[i] = argumentLocalValues[i] = args[i];
                else
                {
                    argumentDefValues[i] = argDefaultValue;
                    argumentLocalValues[i] = argLocalValue;
                }

            }
            return (argumentDefValues, argumentLocalValues);
        }
        private static string GetEntityName(string entityKey, bool localized = false)
        {
            if (localized)
                return _entityResourceManager.GetString(entityKey, _cultureInfo) ?? entityKey;
            else
                return _entityResourceManager.GetString(entityKey) ?? entityKey;

        }
        private static object[] GetArgumentValues(object[] localArgs, string formatString)
        {
            // Get the number of placeholders in the format string
            int placeholderCount = new System.Text.RegularExpressions.Regex(@"\{[^\}]*\}").Matches(formatString).Count;

            // Use all arguments if their count is less than or equal to the number of placeholders
            return localArgs.Take(placeholderCount).ToArray();
        }

    }
}
