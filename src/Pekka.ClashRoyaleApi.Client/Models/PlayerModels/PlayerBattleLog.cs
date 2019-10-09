using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerBattleLog
    {
        public string Type { get; set; }

        public string BattleTime { get; set; }

        public bool IsLadderTournament { get; set; }

        public PlayerBattleLogArena Arena { get; set; }

        public PlayerBattleLogGameMode GameMode { get; set; }

        public string DeckSelection { get; set; }

        public PlayerBattleLogTeam[] Team { get; set; }

        public PlayerBattleLogTeam[] Opponent { get; set; }

        public string ChallengeTitle { get; set; }

        public int? ChallengeId { get; set; }

        public int? ChallengeWinCountBefore { get; set; }
    }
}