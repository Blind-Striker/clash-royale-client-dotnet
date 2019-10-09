using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerBattleLogTeam
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int StartingTrophies { get; set; }

        public int TrophyChange { get; set; }

        public int Crowns { get; set; }

        public int KingTowerHitPoints { get; set; }

        public int[] PrincessTowersHitPoints { get; set; }

        public PlayerBattleLogClan Clan { get; set; }

        public PlayerBattleLogCard[] Cards { get; set; }
    }
}