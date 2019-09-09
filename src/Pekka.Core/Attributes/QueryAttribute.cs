using System;

namespace Pekka.Core.Attributes
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