using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWar
    {
        public string State { get; set; }

        public DateTime CollectionEndTime { get; set; }

        public ClanWarClan Clan { get; set; }

        public ClanWarParticipant[] Participants { get; set; }
    }
}