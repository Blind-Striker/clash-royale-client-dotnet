using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pekka.Core.Helpers
{
    public static class FilterExtensions
    {
        public static IList<KeyValuePair<string, string>> ToQueryParams<TFilterModel>(this TFilterModel filter)
            where TFilterModel : class, new()
        {
            Ensure.ArgumentNotNull(filter, nameof(filter));

            var propertyInfos = filter.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(info => Attribute.IsDefined(info, typeof(QueryAttribute))).ToList();

            if (!propertyInfos.Any())
            {
                return null;
            }

            var queryParams = new List<KeyValuePair<string, string>>();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(filter);
                if (value == null)
                {
                    continue;
                }

                var customAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();
                var queryStringKey = customAttribute.QueryStringKey;

                queryParams.Add(new KeyValuePair<string, string>(queryStringKey, value.ToString()));
            }

            return queryParams;
        }
    }
}
