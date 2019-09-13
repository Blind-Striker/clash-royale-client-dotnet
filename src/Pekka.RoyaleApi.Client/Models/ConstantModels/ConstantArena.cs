using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantArena
    {
        public string Name { get; set; }

        public int Arena { get; set; }

        public string ChestArena { get; set; }

        public string TvArena { get; set; }

        public bool IsInUse { get; set; }

        public bool TrainingCamp { get; set; }

        public int TrophyLimit { get; set; }

        public int DemoteTrophyLimit { get; set; }

        public int ChestRewardMultiplier { get; set; }

        public int ShopChestRewardMultiplier { get; set; }

        public int RequestSize { get; set; }

        public int MaxDonationCountCommon { get; set; }

        public int MaxDonationCountRare { get; set; }

        public int MaxDonationCountEpic { get; set; }

        public int MatchmakingMinTrophyDelta { get; set; }

        public int MatchmakingMaxTrophyDelta { get; set; }

        public int MatchmakingMaxSeconds { get; set; }

        public int DailyDonationCapacityLimit { get; set; }

        public int BattleRewardGold { get; set; }

        public string QuestCycle { get; set; }

        public string Key { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public int ArenaId { get; set; }

        public int Id { get; set; }
    }
}