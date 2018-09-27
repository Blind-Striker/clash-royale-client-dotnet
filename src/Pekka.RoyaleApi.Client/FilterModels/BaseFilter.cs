using System;
using System.Linq.Expressions;
using Pekka.Core;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class BaseFilter<TModel> : IPaginationFilter
    {
        public Expression<Func<TModel, object>> Keys { get; set; }

        public Expression<Func<TModel, object>> Exclude { get; set; }

        [Query("max")]
        public int? Max { get; set; }

        [Query("page")]
        public int? Page { get; set; }
    }

    public interface IPaginationFilter
    {
        [Query("max")]
        int? Max { get; set; }

        [Query("page")]
        int? Page { get; set; }
    }
}