using Pekka.ClashRoyaleApi.Client.Models.ClanModels;

using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class BattleLogTeam
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? StartingTrophies { get; set; }

        public int? TrophyChange { get; set; }

        public int? Crowns { get; set; }

        public ClanBase Clan { get; set; }

        public List<Card> Cards { get; set; }
    }
}