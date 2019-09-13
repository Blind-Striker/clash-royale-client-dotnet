using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.JsonConverters;
using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanBattleTeam: ITeam
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CrownsEarned { get; set; }

        public int StartTrophies { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleClanLight>))]
        public IClanLight Clan { get; set; }

        public string DeckLink { get; set; }

        [JsonConverter(typeof(CustomConverter<ClanBattleDeck[]>))]
        public ICard[] Deck { get; set; }
    }
}
