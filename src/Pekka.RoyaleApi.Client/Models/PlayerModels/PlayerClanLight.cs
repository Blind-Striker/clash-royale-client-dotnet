using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.JsonConverters;
using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerClanLight : IClanLight
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        [JsonConverter(typeof(CustomConverter<PlayerBadge>))]
        public IBadge Badge { get; set; }
    }
}