using Newtonsoft.Json;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    public class LocationRankingTournamentClan
    {
        public int BadgeId { get; set; }

        public string Tag { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(CustomConverter<LocationRankingTournamentClanBadge>))]
        public IIconUrl BadgeUrls { get; set; }
    }
}