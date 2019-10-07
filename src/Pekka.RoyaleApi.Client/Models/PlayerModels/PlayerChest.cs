using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerChest
    {
        public string[] Upcoming { get; set; }

        public int MegaLightning { get; set; }

        public int Magical { get; set; }

        public int Legendary { get; set; }

        public int Epic { get; set; }

        public int Giant { get; set; }
    }
}