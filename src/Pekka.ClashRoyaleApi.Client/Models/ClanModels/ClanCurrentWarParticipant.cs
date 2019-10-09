using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanCurrentWarParticipant : IParticipant
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CardsEarned { get; set; }

        public int BattlesPlayed { get; set; }

        public int Wins { get; set; }

        public int CollectionDayBattlesPlayed { get; set; }

        public int NumberOfBattles { get; set; }
    }
}