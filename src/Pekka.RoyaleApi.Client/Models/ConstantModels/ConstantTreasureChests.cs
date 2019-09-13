using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantTreasureChests
    {
        public ConstantCycle[] Cycle { get; set; }

        public ConstantCrown[] Crown { get; set; }

        public ConstantShop[] Shop { get; set; }
    }
}