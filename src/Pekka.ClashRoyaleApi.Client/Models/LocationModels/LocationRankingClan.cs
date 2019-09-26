using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class LocationRankingClan
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public int PreviousRank { get; set; }

        public Location Location { get; set; }

        public int ClanScore { get; set; }

        public int BadgeId { get; set; }

        public int Members { get; set; }
    }
}