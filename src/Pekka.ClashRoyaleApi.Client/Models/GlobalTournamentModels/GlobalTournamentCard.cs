using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GlobalTournamentCard : ICardLight
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int MaxLevel { get; set; }

        [JsonConverter(typeof(CustomConverter<GlobalTournamentIconUrl>))]
        public IIconUrl IconUrls { get; set; }
    }
}