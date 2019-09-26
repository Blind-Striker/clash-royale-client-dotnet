using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GlobalTournamentReward
    {
        public string Chest { get; set; }

        public string Rarity { get; set; }

        public string Resource { get; set; }

        public string Type { get; set; }

        public int Amount { get; set; }

        [JsonConverter(typeof(CustomConverter<GlobalTournamentCard>))]
        public ICardLight Card { get; set; }

        public int Wins { get; set; }
    }
}