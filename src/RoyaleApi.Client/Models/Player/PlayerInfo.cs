using System.Collections.Generic;

namespace RoyaleApi.Client.Models.Player
{
    public class PlayerInfo
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int CrownsEarned { get; set; }
        public int StartTrophies { get; set; }
        public PlayerClanInfo Clan { get; set; }
        public string DeckLink { get; set; }
        public List<Card> Deck { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}   