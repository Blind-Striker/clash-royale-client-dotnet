using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class Player
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int Trophies { get; set; }

        public int? Rank { get; set; }

        public ArenaInfo Arena { get; set; }

        public PlayerClanInfo Clan { get; set; }

        public PlayerStats Stats { get; set; }

        public PlayerGames Games { get; set; }

        public PlayerLeagueStatistics LeagueStatistics { get; set; }

        public string DeckLink { get; set; }

        public List<Card> CurrentDeck { get; set; }

        public List<Card> Cards { get; set; }

        public List<PlayerAchievement> Achievements { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Tag}";
        }
    }
}