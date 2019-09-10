using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantRegion
    {
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public bool IsCountry { get; set; }
    }
}