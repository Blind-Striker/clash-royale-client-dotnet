﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanWarLog
    {
        public DateTime WarEndTime { get; set; }

        public List<ClanWarParticipant> Participants { get; set; }

        public List<ClanWarClan> Standings { get; set; }

        public int SeasonNumber { get; set; }
    }
}