using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantAllianceBadge
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{Id}-{Name}-{Category}";
        }
    }
}