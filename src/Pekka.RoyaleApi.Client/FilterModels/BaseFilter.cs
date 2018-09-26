using System;
using System.Linq.Expressions;
using Pekka.Core;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class BaseFilter<TModel> : BaseFilter
    {
        public Expression<Func<TModel, object>> Keys { get; set; }

        public Expression<Func<TModel, object>> Exclude { get; set; }
    }

    public class BaseFilter
    {
        [Query("max")]
        public int? Max { get; set; }

        [Query("page")]
        public int? Page { get; set; }
    }
}