using Pekka.ClashRoyaleApi.Client.Models.LocationModels;

using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class Clan
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? BadgeId { get; set; }

        public string Type { get; set; }

        public int? ClanScore { get; set; }

        public int? RequiredTrophies { get; set; }

        public int? DonationsPerWeek { get; set; }

        public int? ClanChestLevel { get; set; }

        public int? ClanChestMaxLevel { get; set; }

        public int? Members { get; set; }

        public Location Location { get; set; }

        public string Description { get; set; }

        public string ClanChestStatus { get; set; }

        public int? ClanChestPoints { get; set; }

        public ClanMember[] MemberList { get; set; }
    }
}