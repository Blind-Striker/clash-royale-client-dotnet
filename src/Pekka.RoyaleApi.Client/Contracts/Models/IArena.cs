namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IArena
    {
        int Id { get; set; }

        string Name { get; set; }

        string Arena { get; set; }

        int TrophyLimit { get; set; }
    }
}