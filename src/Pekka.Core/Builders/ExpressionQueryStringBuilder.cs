using Pekka.Core.Attributes;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Pekka.Core.Builders
{
    public class ExpressionQueryStringBuilder : QueryStringBuilder
    {
        public override void ProcessRequest<TFilterModel>(IList<KeyValuePair<string, string>> queryStringParams, TFilterModel filter)
        {
            Ensure.ArgumentNotNull(filter, nameof(filter));

            List<PropertyInfo> propertyInfos = filter.GetType()
                                                     .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                                     .Where(info => Attribute.IsDefined(info, typeof(ExpressionQueryAttribute)) &&
                                                                    info.PropertyType.IsArray &&
                                                                    info.PropertyType.GetElementType()?.BaseType == typeof(LambdaExpression))
                                                     .ToList();

            if (!propertyInfos.Any()) Successor?.ProcessRequest(queryStringParams, filter);

            queryStringParams = queryStringParams ?? new List<KeyValuePair<string, string>>();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                if (!(propertyInfo.GetValue(filter) is Array value) || value.Length == 0) continue;

                var customAttribute = propertyInfo.GetCustomAttribute<ExpressionQueryAttribute>();
                string queryStringKey = customAttribute.KeyName;
                var queryStringValueBuilder = new StringBuilder();

                for (var i = 0; i < value.Length; i++)
                {
                    if (!(value.GetValue(i) is LambdaExpression lambdaExpression)) continue;

                    PropertyInfo extractedPropertyInfo = ExtractPropertyInfo(lambdaExpression);

                    queryStringValueBuilder.Append(extractedPropertyInfo.Name.ToCamelCase());
                    queryStringValueBuilder.Append(",");
                }

                queryStringParams.Add(new KeyValuePair<string, string>(queryStringKey, queryStringValueBuilder.ToString().Remove(queryStringValueBuilder.Length - 1)));
            }

            Successor?.ProcessRequest(queryStringParams, filter);
        }

        private static PropertyInfo ExtractPropertyInfo(LambdaExpression propertyLambda)
        {
            //MemberExpression member = propertyLambda.Body as MemberExpression;
            MemberExpression member = GetMemberExpression(propertyLambda);

            if (member == null)
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");

            var propInfo = member.Member as PropertyInfo;

            if (propInfo == null)
                throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");

            return propInfo;
        }

        private static MemberExpression GetMemberExpression(LambdaExpression exp)
        {
            var member = exp.Body as MemberExpression;
            var unary = exp.Body as UnaryExpression;

            return member ?? unary?.Operand as MemberExpression;
        }
    }
}