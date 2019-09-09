using Pekka.Core.Builders;
using Pekka.Core.Contracts;

using System.Collections.Generic;

namespace Pekka.Core.Extensions
{
    public static class FilterExtensions
    {
        public static IList<KeyValuePair<string, string>> ToQueryParams<TFilterModel>(this TFilterModel filter)
            where TFilterModel : class, IFilter, new()
        {
            var expressionQueryStringBuilder = new ExpressionQueryStringBuilder();
            var propertyQueryStringBuilder = new PropertyQueryStringBuilder();
            propertyQueryStringBuilder.SetSuccessor(expressionQueryStringBuilder);

            var queryParameters = new List<KeyValuePair<string, string>>();

            propertyQueryStringBuilder.ProcessRequest(queryParameters, filter);

            return queryParameters;
        }
    }
}