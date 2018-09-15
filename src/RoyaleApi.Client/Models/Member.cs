namespace RoyaleApi.Client.Models
{
    public class Member
    {
        public string Name { get; set; }
        public string Tag { get; set; }
        public int Rank { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
        public int DonationsDelta { get; set; }
        public ArenaInfo Arena { get; set; }
        public double DonationsPercent { get; set; }
        public int? PreviousRank { get; set; }
    }
}