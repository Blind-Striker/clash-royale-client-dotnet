using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.LocationModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Location
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCountry { get; set; }

        public string CountryCode { get; set; }
    }
}