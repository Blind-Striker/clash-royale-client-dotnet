using System;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.JsonConverters;
using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerBattle : IBattle
    {
        public string Type { get; set; }

        public DateTime UtcTime { get; set; }

        public string DeckType { get; set; }

        public int WinCountBefore { get; set; }

        public int TeamSize { get; set; }

        public int Winner { get; set; }

        public int TeamCrowns { get; set; }

        public int OpponentCrowns { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerArena>))]
        public IArena Arena { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerMode>))]
        public IMode Mode { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerTeam[]>))]
        public ITeam[] Team { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerTeam[]>))]
        public ITeam[] Opponent { get; set; }
    }
}