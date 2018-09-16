using RoyaleApi.Client.Models.Player;

namespace RoyaleApi.Client.Models.Clan
{
    public class ClanMember
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Rank { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int? Donations { get; set; }
        public int? DonationsReceived { get; set; }
        public int? DonationsDelta { get; set; }
        public ArenaInfo Arena { get; set; }
        public double? DonationsPercent { get; set; }
        public int? PreviousRank { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}