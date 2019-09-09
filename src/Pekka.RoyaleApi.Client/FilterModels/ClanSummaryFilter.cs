using Pekka.Core;
using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class ClanSummaryFilter : BaseFilter<ClanSummary>
    {
        [Query("name")]
        public string Name { get; set; }

        [Query("locationId")]
        public int? LocationId { get; set; }

        [Query("minMembers")]
        public int? MinMembers { get; set; }

        [Query("maxMembers")]
        public int? MaxMembers { get; set; }

        [Query("score")]
        public int? Score { get; set; }

        [Query("limit")]
        public int? Limit { get; set; }
    }
}