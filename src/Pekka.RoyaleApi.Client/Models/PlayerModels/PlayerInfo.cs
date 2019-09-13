using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerInfo
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CrownsEarned { get; set; }

        public int StartTrophies { get; set; }

        public PlayerClan Clan { get; set; }

        public string DeckLink { get; set; }

        public PlayerCard[] Deck { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}