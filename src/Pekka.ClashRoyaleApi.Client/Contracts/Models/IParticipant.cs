namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface IParticipant : IModel
    {
        string Tag { get; set; }

        string Name { get; set; }

        int CardsEarned { get; set; }

        int BattlesPlayed { get; set; }

        int Wins { get; set; }

        int CollectionDayBattlesPlayed { get; set; }

        int NumberOfBattles { get; set; }
    }
}