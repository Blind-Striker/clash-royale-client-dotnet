using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWarLog
    {
        public int CreatedDate { get; set; }

        public List<ClanWarParticipant> Participants { get; set; }

        public List<ClanWarInfoClan> Standings { get; set; }

        public int SeasonNumber { get; set; }
    }
}