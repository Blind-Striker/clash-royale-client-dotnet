namespace RoyaleApi.Client.Models.Player
{
    public class PlayerSummary
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int? Rank { get; set; }
        public int? PreviousRank { get; set; }
        public int ExpLevel { get; set; }
        public int Trophies { get; set; }
        public int? DonationsDelta { get; set; }
        public PlayerClanInfo Clan { get; set; }
        public string DeckLink { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}