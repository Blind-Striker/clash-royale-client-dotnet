using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantPrize
    {
        public int Rank { get; set; }

        public int Cards { get; set; }

        public int Tier { get; set; }
    }
}