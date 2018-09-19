using Pekka.Core;
using Pekka.RoyaleApi.Client.Contracts;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class Pagination : IPagination
    {
        [Query("max")]
        public int? Max { get; set; }

        [Query("page")]
        public int? Page { get; set; }
    }
}