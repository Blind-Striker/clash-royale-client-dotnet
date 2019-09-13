using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerLeagueStatistics
    {
        public PlayerCurrentSeason CurrentSeason { get; set; }

        public PlayerPreviousSeason PreviousSeason { get; set; }

        public PlayerBestSeason BestSeason { get; set; }
    }
}