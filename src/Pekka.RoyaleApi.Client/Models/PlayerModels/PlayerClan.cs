using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerClan : PlayerClanLight
    {
        public string Role { get; set; }

        public int Donations { get; set; }

        public int DonationsDelta { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}