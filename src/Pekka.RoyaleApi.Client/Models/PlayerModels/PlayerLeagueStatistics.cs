namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerLeagueStatistics
    {
        public PlayerSeason CurrentSeason { get; set; }
        public PlayerSeason PreviousSeason { get; set; }
        public PlayerSeason BestSeason { get; set; }
    }
}