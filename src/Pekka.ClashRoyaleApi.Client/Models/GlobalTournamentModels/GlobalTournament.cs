using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GlobalTournament
    {
        public GlobalTournamentGameMode GameMode { get; set; }

        public int MaxLosses { get; set; }

        public int MinExpLevel { get; set; }

        public int TournamentLevel { get; set; }

        public GlobalTournamentReward[] MilestoneRewards { get; set; }

        public GlobalTournamentReward[] FreeTierRewards { get; set; }

        public string Tag { get; set; }

        public string Title { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        public GlobalTournamentReward[] TopRankReward { get; set; }

        public int MaxTopRewardRank { get; set; }
    }
}