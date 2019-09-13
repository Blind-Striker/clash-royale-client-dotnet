using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerLeagueStatistics
    {
        public PlayerSeason CurrentSeason { get; set; }

        public PlayerSeason PreviousSeason { get; set; }

        public PlayerSeason BestSeason { get; set; }
    }
}