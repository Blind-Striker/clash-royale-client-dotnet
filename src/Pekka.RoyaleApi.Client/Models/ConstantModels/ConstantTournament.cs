using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantTournament
    {
        public int CreateCost { get; set; }

        public int MaxPlayers { get; set; }

        public string Key { get; set; }

        public ConstantPrize[] Prizes { get; set; }

        public int[] Cards { get; set; }
    }
}