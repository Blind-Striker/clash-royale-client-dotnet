using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerAchievement
    {
        public string Name { get; set; }

        public int Stars { get; set; }

        public int Value { get; set; }

        public int Target { get; set; }

        public string Info { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}