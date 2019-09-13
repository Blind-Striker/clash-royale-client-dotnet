using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanRegion
    {
        public string Name { get; set; }

        public bool IsCountry { get; set; }

        public string Code { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}