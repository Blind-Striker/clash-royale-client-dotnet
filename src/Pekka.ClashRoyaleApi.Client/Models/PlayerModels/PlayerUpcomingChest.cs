using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerUpcomingChest
    {
        public int Index { get; set; }

        public string Name { get; set; }

        public PlayerIconUrl IconUrls { get; set; }
    }
}