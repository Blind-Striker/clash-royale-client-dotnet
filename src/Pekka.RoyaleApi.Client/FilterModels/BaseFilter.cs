using Pekka.Core.Attributes;
using Pekka.Core.Contracts;

using System;
using System.Linq.Expressions;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class BaseFilter<TModel> : IPaginationFilter
    {
        [ExpressionQuery("keys")]
        public Expression<Func<TModel, object>>[] Keys { get; set; }

        [ExpressionQuery("exclude")]
        public Expression<Func<TModel, object>>[] Excludes { get; set; }

        [Query("max")]
        public int? Max { get; set; }

        [Query("page")]
        public int? Page { get; set; }
    }

    public interface IPaginationFilter : IFilter
    {
        [Query("max")]
        int? Max { get; set; }

        [Query("page")]
        int? Page { get; set; }
    }
}