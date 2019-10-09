using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantRarity
    {
        public string Name { get; set; }

        public int LevelCount { get; set; }

        public int RelativeLevel { get; set; }

        public int MirrorRelativeLevel { get; set; }

        public int CloneRelativeLevel { get; set; }

        public int DonateCapacity { get; set; }

        public int SortCapacity { get; set; }

        public int DonateReward { get; set; }

        public int DonateXp { get; set; }

        public int GoldConversionValue { get; set; }

        public int ChanceWeight { get; set; }

        public int BalanceMultiplier { get; set; }

        public int[] UpgradeExp { get; set; }

        public int[] UpgradeMaterialCount { get; set; }

        public int[] UpgradeCost { get; set; }

        public int[] PowerLevelMultiplier { get; set; }

        public int RefundGems { get; set; }
    }
}