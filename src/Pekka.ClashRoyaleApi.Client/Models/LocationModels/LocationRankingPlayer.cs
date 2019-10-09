using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LocationRankingPlayer
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int ExpLevel { get; set; }

        public int Trophies { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        [JsonConverter(typeof(CustomConverter<LocationRankingPlayerClan>))]
        public IClanLight Clan { get; set; }

        [JsonConverter(typeof(CustomConverter<LocationRankingPlayerArena>))]
        public IArena Arena { get; set; }
    }
}