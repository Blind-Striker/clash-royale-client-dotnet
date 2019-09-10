using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantQuestChest
    {
        public string Chest { get; set; }

        public string ArenaThreshold { get; set; }

        public bool OneTime { get; set; }
    }
}