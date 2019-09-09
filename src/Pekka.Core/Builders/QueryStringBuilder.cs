using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using System.Collections.Generic;

namespace Pekka.Core.Builders
{
    public abstract class QueryStringBuilder
    {
        protected QueryStringBuilder Successor;

        public void SetSuccessor(QueryStringBuilder successor)
        {
            Ensure.ArgumentNotNull(successor, nameof(successor));

            Successor = successor;
        }

        public abstract void ProcessRequest<TFilterModel>(IList<KeyValuePair<string, string>> queryStringParams,
            TFilterModel filter) where TFilterModel : class, IFilter, new();
    }
}