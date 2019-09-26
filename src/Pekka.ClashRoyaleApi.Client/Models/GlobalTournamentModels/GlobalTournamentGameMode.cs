using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class GlobalTournamentGameMode
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}