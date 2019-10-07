using System.Collections.Generic;
using System.Linq;

namespace Pekka.Core.Tests.Helpers
{
    public static class InlineDataHelpers
    {
        public static IList<KeyValuePair<string, string>> ToQueryStingParameters(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            string[] @params = value.Split(';');

            IList<KeyValuePair<string, string>> queryStringParameters = @params
                                                                        .Select(param => param.Split('='))
                                                                        .Select(keyValues => new KeyValuePair<string, string>(keyValues[0], keyValues[1]))
                                                                        .ToList();

            return queryStringParameters;
        }

        public static IDictionary<string, string> ToHeaderParameters(this string value)
        {
            if (string.IsNullOrEmpty(value)) return null;

            IDictionary<string, string> headerParameters = new Dictionary<string, string>();

            string[] @params = value.Split(';');

            foreach (string param in @params)
            {
                string[] keyValues = param.Split('=');

                headerParameters.Add(new KeyValuePair<string, string>(keyValues[0], keyValues[1]));
            }

            return headerParameters;
        }
    }
}