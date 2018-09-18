using Pekka.ClashRoyaleApi.Client.Models.ClanModels;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerRankingListItem
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public int? Rank { get; set; }

        public int? PreviousRank { get; set; }

        public ClanBase Clan { get; set; }

        public Arena Arena { get; set; }
    }
}
