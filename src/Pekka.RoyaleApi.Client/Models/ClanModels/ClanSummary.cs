using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanSummary
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public int Score { get; set; }

        public int MemberCount { get; set; }

        public int RequiredScore { get; set; }

        public int Donations { get; set; }

        public PlayerBadge Badge { get; set; }

        public ClanRegion Location { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}