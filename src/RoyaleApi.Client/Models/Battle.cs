using System.Collections.Generic;

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
        public List<Team> Team { get; set; }
        public List<Opponent> Opponent { get; set; }
        public ArenaInfo Arena { get; set; }
    }
}