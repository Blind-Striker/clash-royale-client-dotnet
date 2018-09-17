namespace Pekka.RoyaleApi.Client.Models.Clan
{
    public class ClanWarInfoClan
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int Participants { get; set; }
        public int BattlesPlayed { get; set; }
        public int Wins { get; set; }
        public int Crowns { get; set; }
        public int WarTrophies { get; set; }
        public int WarTrophiesChange { get; set; }
        public Badge Badge { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}