using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWar
    {
        public string State { get; set; }

        public ClanWarInfoClan Clan { get; set; }

        public ClanWarParticipant[] Participants { get; set; }

        public int SeasonNumber { get; set; }

        public int? WarEndTime { get; set; }

        public int? CollectionEndTime { get; set; }

        public int? StageEndTime => WarEndTime ?? CollectionEndTime.GetValueOrDefault();
    }
}