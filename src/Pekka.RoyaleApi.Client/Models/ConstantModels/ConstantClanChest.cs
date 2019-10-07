using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantClanChest
    {
        [JsonProperty("1v1")]
        public ConstantChestXvX OneVOne { get; set; }

        [JsonProperty("2v2")]
        public ConstantChestXvX TwoVTwo { get; set; }
    }
}