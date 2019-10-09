using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LocationRankingPlayerClan : IClanLight
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int BadgeId { get; set; }
    }
}