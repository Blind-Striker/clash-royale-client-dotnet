using System;
using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerBattle
    {
        public string Type { get; set; }

        public DateTime UtcTime { get; set; }

        public string DeckType { get; set; }

        public int WinCountBefore { get; set; }

        public int TeamSize { get; set; }

        public int Winner { get; set; }

        public int TeamCrowns { get; set; }

        public int OpponentCrowns { get; set; }

        public PlayerArena Arena { get; set; }

        public PlayerMode Mode { get; set; }

        public List<PlayerTeam> Team { get; set; }

        public List<PlayerTeam> Opponent { get; set; }
    }
}