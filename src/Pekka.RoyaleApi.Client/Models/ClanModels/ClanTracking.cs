using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanTracking
    {
        public bool Active { get; set; }

        public bool Legible { get; set; }

        public bool Available { get; set; }

        public int SnapshotCount { get; set; }
    }
}