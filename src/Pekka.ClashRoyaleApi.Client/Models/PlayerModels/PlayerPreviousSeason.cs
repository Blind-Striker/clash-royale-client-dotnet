using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerPreviousSeason
    {
        public string Id { get; set; }

        public int Trophies { get; set; }

        public int BestTrophies { get; set; }
    }
}