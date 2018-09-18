using Pekka.ClashRoyaleApi.Client.Models.LocationModels;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class ClanRankingListItem
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? Rank { get; set; }

        public int? PreviousRank { get; set; }

        public Location Location { get; set; }

        public int? ClanScore { get; set; }

        public int? BadgeId { get; set; }

        public int? Members { get; set; }
    }
}
