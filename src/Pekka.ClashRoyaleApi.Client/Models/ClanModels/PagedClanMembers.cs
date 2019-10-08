using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PagedClanMembers : IPaged<ClanMember>
    {
        public ClanMember[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}