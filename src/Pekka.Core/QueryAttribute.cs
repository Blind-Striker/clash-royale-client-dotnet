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
}
