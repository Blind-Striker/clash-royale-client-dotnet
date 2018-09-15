using System.Collections.Generic;

namespace RoyaleApi.Client.Models
{
    public class Opponent
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int CrownsEarned { get; set; }
        public int StartTrophies { get; set; }
        public ClanInfo Clan { get; set; }
        public string DeckLink { get; set; }
        public List<Deck> Deck { get; set; }
    }
}   