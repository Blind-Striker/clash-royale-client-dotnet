namespace Pekka.ClashRoyaleApi.Client.Contracts.Models
{
    public interface ICard : ICardLight
    {
        int Level { get; set; }

        int Count { get; set; }
    }
}