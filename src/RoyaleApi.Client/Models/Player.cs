using System.Collections.Generic;

namespace RoyaleApi.Client.Models
{
    public class Player
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int Trophies { get; set; }
        public int? Rank { get; set; }
        public ArenaInfo Arena { get; set; }
        public ClanInfo Clan { get; set; }
        public Stats Stats { get; set; }
        public Games Games { get; set; }
        public LeagueStatistics LeagueStatistics { get; set; }
        public string DeckLink { get; set; }
        public List<CurrentDeck> CurrentDeck { get; set; }
        public List<Card> Cards { get; set; }
        public List<Achievement> Achievements { get; set; }
    }
}