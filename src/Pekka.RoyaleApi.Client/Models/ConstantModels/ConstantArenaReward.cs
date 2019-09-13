using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantArenaReward
    {
        public string Name { get; set; }

        public int Arena { get; set; }

        public int ChestRewardMultiplier { get; set; }

        public int ShopChestRewardMultiplier { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public double? CardCountByArena { get; set; }

        public double? CardCountCommon { get; set; }

        public double? CardCountRare { get; set; }

        public double? CardCountEpic { get; set; }

        public double? CardCountLegendary { get; set; }
    }
}