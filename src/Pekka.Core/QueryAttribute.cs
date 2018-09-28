using System;

namespace Pekka.Core
{
    public class QueryAttribute : Attribute
    {
        public QueryAttribute(string queryStringKey)
        {
            QueryStringKey = queryStringKey;
        }

        public string QueryStringKey { get; }
    }

    public class ExpressionQueryAttribute : Attribute
    {
        public ExpressionQueryAttribute(string keyName)
        {
            KeyName = keyName;
        }

        public string KeyName { get; }
    }
}
