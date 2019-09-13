using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class Player
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int Trophies { get; set; }

        public PlayerArena Arena { get; set; }

        public PlayerClan Clan { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerGame Games { get; set; }

        public PlayerLeagueStatistics LeagueStatistics { get; set; }

        public string DeckLink { get; set; }

        public PlayerCard[] CurrentDeck { get; set; }

        public PlayerCard[] Cards { get; set; }

        public PlayerAchievement[] Achievements { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}