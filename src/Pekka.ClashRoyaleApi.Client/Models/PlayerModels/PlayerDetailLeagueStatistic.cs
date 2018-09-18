namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerDetailLeagueStatistic
    {
        public SeasonStatistic CurrentSeason { get; set; }

        public SeasonStatistic PreviousSeason { get; set; }

        public SeasonStatistic BestSeason { get; set; }
    }
}
