using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerSeason
    {
        public string Id { get; set; }

        public int Rank { get; set; }

        public int Trophies { get; set; }

        public int? BestTrophies { get; set; }
    }
}