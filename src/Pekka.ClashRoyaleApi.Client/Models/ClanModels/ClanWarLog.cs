using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWarLog
    {
        public int SeasonId { get; set; }

        public string CreatedDate { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanWarLogParticipant>))]
        public IParticipant[] Participants { get; set; }

        public ClanWarLogStanding[] Standings { get; set; }
    }
}