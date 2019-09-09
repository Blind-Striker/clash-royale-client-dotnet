using System.Collections.Generic;

using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    public class Clan
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Score { get; set; }

        public int MemberCount { get; set; }

        public int RequiredScore { get; set; }

        public int Donations { get; set; }

        public ClanChest ClanChest { get; set; }

        public PlayerBadge Badge { get; set; }

        public ClanRegion Location { get; set; }

        public IList<ClanMember> Members { get; set; }

        public ClanTracking Tracking { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}