using System.Collections.Generic;
using RoyaleApi.Client.Models.Player;

namespace RoyaleApi.Client.Models
{
    public class Battle
    {
        public string Type { get; set; }
        public string ChallengeType { get; set; }
        public Mode Mode { get; set; }
        public int? WinCountBefore { get; set; }
        public int UtcTime { get; set; }
        public string DeckType { get; set; }
        public int TeamSize { get; set; }
        public int Winner { get; set; }
        public int TeamCrowns { get; set; }
        public int OpponentCrowns { get; set; }
        public List<PlayerInfo> Team { get; set; }
        public List<PlayerInfo> Opponent { get; set; }
        public ArenaInfo Arena { get; set; }
    }
}