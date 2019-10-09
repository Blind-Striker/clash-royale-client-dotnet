using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanCurrentWarClan : IClanSummary
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int BadgeId { get; set; }

        public int ClanScore { get; set; }

        public int Participants { get; set; }

        public int BattlesPlayed { get; set; }

        public int Wins { get; set; }

        public int Crowns { get; set; }
    }
}