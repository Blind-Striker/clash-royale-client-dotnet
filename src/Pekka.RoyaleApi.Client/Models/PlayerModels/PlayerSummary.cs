using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerSummary
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? Rank { get; set; }

        public int? PreviousRank { get; set; }

        public int ExpLevel { get; set; }

        public int Trophies { get; set; }

        public int? DonationsDelta { get; set; }

        public PlayerClan Clan { get; set; }

        public string DeckLink { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}