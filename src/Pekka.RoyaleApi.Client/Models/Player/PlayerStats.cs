namespace Pekka.RoyaleApi.Client.Models.Player
{
    public class PlayerStats
    {
        public int ClanCardsCollected { get; set; }
        public int TournamentCardsWon { get; set; }
        public int MaxTrophies { get; set; }
        public int ThreeCrownWins { get; set; }
        public int CardsFound { get; set; }
        public Card FavoriteCard { get; set; }
        public int TotalDonations { get; set; }
        public int ChallengeMaxWins { get; set; }
        public int ChallengeCardsWon { get; set; }
        public int Level { get; set; }
    }
}