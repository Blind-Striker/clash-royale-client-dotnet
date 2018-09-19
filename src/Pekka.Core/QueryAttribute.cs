using System;

namespace Pekka.Core
{
    public class QueryAttribute : Attribute
    {
        public QueryAttribute(string queryStringkey)
        {
            QueryStringkey = queryStringkey;
        }

        public string QueryStringkey { get; }
    }
}
