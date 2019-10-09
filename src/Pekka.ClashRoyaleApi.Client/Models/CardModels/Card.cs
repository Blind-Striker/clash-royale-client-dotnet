using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.Core.JsonConverters;

namespace Pekka.ClashRoyaleApi.Client.Models.CardModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Card : ICardLight
    {
        public string Name { get; set; }

        public int Id { get; set; }

        public int MaxLevel { get; set; }

        [JsonConverter(typeof(CustomConverter<CardIconUrl>))]
        public IIconUrl IconUrls { get; set; }
    }
}