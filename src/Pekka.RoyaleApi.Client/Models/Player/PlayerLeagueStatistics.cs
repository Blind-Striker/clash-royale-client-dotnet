namespace Pekka.RoyaleApi.Client.Models.Player
{
    public class PlayerLeagueStatistics
    {
        public PlayerSeason CurrentSeason { get; set; }
        public PlayerSeason PreviousSeason { get; set; }
        public PlayerSeason BestSeason { get; set; }
    }
}