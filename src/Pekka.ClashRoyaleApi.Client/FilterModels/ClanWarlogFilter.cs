using Pekka.Core;
using IFilter = Pekka.ClashRoyaleApi.Client.Contracts.IFilter;

namespace Pekka.ClashRoyaleApi.Client.FilterModels
{
    public class ClanWarlogFilter : IFilter
    {
        [Query("limit")]
        public int? Limit { get; set; }

        [Query("after")]
        public int? After { get; set; }

        [Query("before")]
        public int? Before { get; set; }
    }
}