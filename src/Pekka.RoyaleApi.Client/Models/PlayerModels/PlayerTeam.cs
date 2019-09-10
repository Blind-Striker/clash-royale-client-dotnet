using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.JsonConverters;
using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerTeam: ITeam
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CrownsEarned { get; set; }

        public int StartTrophies { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerClanLight>))]
        public IClanLight Clan { get; set; }

        public string DeckLink { get; set; }

        [JsonConverter(typeof(CustomConverter<List<PlayerCard>>))]
        public List<ICard> Deck { get; set; }
    }
}