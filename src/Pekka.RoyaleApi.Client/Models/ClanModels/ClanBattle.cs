using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.JsonConverters;
using Pekka.RoyaleApi.Client.Contracts.Models;

using System;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanBattle : IBattle
    {
        public string Type { get; set; }

        public DateTime UtcTime { get; set; }

        public string DeckType { get; set; }

        public int WinCountBefore { get; set; }

        public int TeamSize { get; set; }

        public int Winner { get; set; }

        public int TeamCrowns { get; set; }

        public int OpponentCrowns { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleArena>))]
        public IArena Arena { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleMode>))]
        public IMode Mode { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleTeam[]>))]
        public ITeam[] Team { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleTeam[]>))]
        public ITeam[] Opponent { get; set; }
    }
}