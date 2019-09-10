using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanHistoryPlayer
    {
        public int ClanRank { get; set; }

        public int Donations { get; set; }

        public string Name { get; set; }

        public string Tag { get; set; }

        public int Trophies { get; set; }
    }
}