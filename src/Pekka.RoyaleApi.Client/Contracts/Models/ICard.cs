namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface ICard : IModel
    {
        string Name { get; set; }

        int Level { get; set; }

        int DisplayLevel { get; set; }

        int StarLevel { get; set; }

        int MaxLevel { get; set; }

        int MinLevel { get; set; }

        int Count { get; set; }

        int RequiredForUpgrade { get; set; }

        int LeftToUpgrade { get; set; }

        bool ReadyForUpgrade { get; set; }

        bool Maxed { get; set; }

        string Rarity { get; set; }

        string Type { get; set; }

        int Elixir { get; set; }

        int Arena { get; set; }

        string Icon { get; set; }

        string Description { get; set; }

        string Key { get; set; }

        int Id { get; set; }
    }
}