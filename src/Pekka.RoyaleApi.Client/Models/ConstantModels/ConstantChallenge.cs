using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantChallenge
    {
        public string Name { get; set; }

        public string GameMode { get; set; }

        public bool Enabled { get; set; }

        public int JoinCost { get; set; }

        public string JoinCostResource { get; set; }

        public int MaxWins { get; set; }

        public int MaxLoss { get; set; }

        public int[] RewardGold { get; set; }

        public int[] RewardCards { get; set; }

        public string Key { get; set; }

        public int Id { get; set; }
    }
}