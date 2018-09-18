namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerGames
    {
        public int Total { get; set; }
        public int TournamentGames { get; set; }
        public int Wins { get; set; }
        public int WarDayWins { get; set; }
        public double WinsPercent { get; set; }
        public int Losses { get; set; }
        public double LossesPercent { get; set; }
        public int Draws { get; set; }
        public double DrawsPercent { get; set; }
    }
}