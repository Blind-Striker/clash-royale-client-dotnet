using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerTeam
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int CrownsEarned { get; set; }

        public int StartTrophies { get; set; }

        public PlayerClanLight Clan { get; set; }

        public string DeckLink { get; set; }

        public List<PlayerCard> Deck { get; set; }
    }
}