using Pekka.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Pekka.Core.Builders
{
    public class PropertyQueryStringBuilder : QueryStringBuilder
    {
        public override void ProcessRequest<TFilterModel>(IList<KeyValuePair<string, string>> queryStringParams, TFilterModel filter)
        {
            Ensure.ArgumentNotNull(filter, nameof(filter));

            var propertyInfos = filter.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(info => Attribute.IsDefined(info, typeof(QueryAttribute))).ToList();

            if (!propertyInfos.Any())
            {
                Successor?.ProcessRequest(queryStringParams, filter);
                return;
            }

            queryStringParams = queryStringParams ?? new List<KeyValuePair<string, string>>();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(filter);
                if (value == null)
                {
                    continue;
                }

                var customAttribute = propertyInfo.GetCustomAttribute<QueryAttribute>();
                var queryStringKey = customAttribute.QueryStringKey;

                queryStringParams.Add(new KeyValuePair<string, string>(queryStringKey, value.ToString()));
            }

            Successor?.ProcessRequest(queryStringParams, filter);
        }
    }
}