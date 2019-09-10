using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Clan
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public int Score { get; set; }

        public int WarTrophies { get; set; }

        public int MemberCount { get; set; }

        public int RequiredScore { get; set; }

        public int Donations { get; set; }

        public ClanBadge Badge { get; set; }

        public ClanLocation Location { get; set; }

        public List<ClanMember> Members { get; set; }

        public ClanTracking Tracking { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}