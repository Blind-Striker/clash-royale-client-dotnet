using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.TournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Tournament
    {
        public string Tag { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string CreatorTag { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int LevelCap { get; set; }

        public int FirstPlaceCardPrize { get; set; }

        public int Capacity { get; set; }

        public int MaxCapacity { get; set; }

        public int PreparationDuration { get; set; }

        public int Duration { get; set; }

        public string CreatedTime { get; set; }

        public TournamentGameMode GameMode { get; set; }
    }
}