using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.RoyaleApi.Client.Contracts.Models;

namespace Pekka.RoyaleApi.Client.Models.ClanModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ClanBattleDeck : ICard
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int DisplayLevel { get; set; }

        public int StarLevel { get; set; }

        public int MaxLevel { get; set; }

        public int MinLevel { get; set; }

        public int Count { get; set; }

        public int RequiredForUpgrade { get; set; }

        public int LeftToUpgrade { get; set; }

        public bool ReadyForUpgrade { get; set; }

        public bool Maxed { get; set; }

        public string Rarity { get; set; }

        public string Type { get; set; }

        public int Elixir { get; set; }

        public int Arena { get; set; }

        public string Icon { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Name}";
        }
    }
}
