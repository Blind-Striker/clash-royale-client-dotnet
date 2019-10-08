using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanCurrentWar
    {
        public string State { get; set; }

        public string WarEndTime { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanCurrentWarClan>))]
        public IClanSummary Clan { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanCurrentWarParticipant[]>))]
        public IParticipant[] Participants { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanCurrentWarParticipant[]>))]
        public IParticipant[] Clans { get; set; }
    }
}