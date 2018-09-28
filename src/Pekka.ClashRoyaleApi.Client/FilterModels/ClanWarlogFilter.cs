using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core;

namespace Pekka.ClashRoyaleApi.Client.FilterModels
{
    public class ClanWarlogFilter : IApiFilter
    {
        [Query("limit")]
        public int? Limit { get; set; }

        [Query("after")]
        public int? After { get; set; }

        [Query("before")]
        public int? Before { get; set; }
    }
}