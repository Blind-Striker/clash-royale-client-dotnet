using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanLocation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsCountry { get; set; }
    }
}