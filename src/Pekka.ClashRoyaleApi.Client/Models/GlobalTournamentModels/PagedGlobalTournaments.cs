using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PagedGlobalTournaments: IPaged<GlobalTournament>
    {
        public GlobalTournament[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}