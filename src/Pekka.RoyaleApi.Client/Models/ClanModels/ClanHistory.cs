using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanHistory
    {
        public int Donations { get; set; }

        public int MemberCount { get; set; }

        public ClanHistoryMember[] Members { get; set; }
    }
}