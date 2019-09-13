using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class BattleLog
    {
        public string Type { get; set; }

        public string BattleTime { get; set; }

        public Arena Arena { get; set; }

        public BattleLogGameMode GameMode { get; set; }

        public string DeckSelection { get; set; }

        public List<BattleLogTeam> Team { get; set; }

        public List<BattleLogTeam> Opponent { get; set; }
    }
}