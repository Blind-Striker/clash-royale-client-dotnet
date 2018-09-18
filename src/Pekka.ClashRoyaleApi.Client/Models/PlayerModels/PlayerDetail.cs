using System.Collections.Generic;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class PlayerDetail
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? ExpLevel { get; set; }

        public int? Trophies { get; set; }

        public Arena Arena { get; set; }

        public int? BestTrophies { get; set; }

        public int? Wins { get; set; }

        public int? Losses { get; set; }

        public int? BattleCount { get; set; }

        public int? ThreeCrownWins { get; set; }

        public int? ChallengeCardsWon { get; set; }

        public int? ChallengeMaxWins { get; set; }

        public int? TournamentCardsWon { get; set; }

        public int? TournamentBattleCount { get; set; }

        public string Role { get; set; }

        public int? Donations { get; set; }

        public int? DonationsReceived { get; set; }

        public int? TotalDonations { get; set; }

        public int? WarDayWins { get; set; }

        public int? ClanCardsCollected { get; set; }

        public ClanBase Clan { get; set; }

        public PlayerDetailLeagueStatistic LeagueStatistics { get; set; }

        public List<PlayerDetailAchievement> Achievements { get; set; }

        public List<PlayerDetailCards> Cards { get; set; }

        public Card CurrentFavouriteCard { get; set; }
    }
}
