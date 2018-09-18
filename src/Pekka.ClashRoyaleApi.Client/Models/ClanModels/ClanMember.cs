namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class ClanMember
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public Arena Arena { get; set; }

        public string Role { get; set; }

        public int? ClanRank { get; set; }

        public int? PreviousClanRank { get; set; }

        public int? Donations { get; set; }

        public int? DonationsReceived { get; set; }

        public int? ClanChestPoints { get; set; }
    }
}
