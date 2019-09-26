using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LocationRankingPlayers : IPaged<LocationRankingPlayer>
    {
        public LocationRankingPlayer[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}