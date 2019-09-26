using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.ClashRoyaleApi.Client.Models.TournamentModels;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanMembers : IPaged<ClanMember>
    {
        public ClanMember[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}