using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWarParticipant
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CardsEarned { get; set; }

        public int BattleCount { get; set; }

        public int BattlesPlayed { get; set; }

        public int BattlesMissed { get; set; }

        public int Wins { get; set; }

        public int CollectionDayBattlesPlayed { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}