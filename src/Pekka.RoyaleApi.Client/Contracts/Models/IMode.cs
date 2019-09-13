namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IMode : IModel
    {
        int Id { get; set; }

        string Name { get; set; }

        string CardLevelAdjustment { get; set; }

        string DeckSelection { get; set; }

        int OvertimeSeconds { get; set; }

        bool SameDeckOnBoth { get; set; }

        bool SeparateTeamDecks { get; set; }

        bool SwappingTowers { get; set; }

        bool UseStartingElixir { get; set; }

        bool RandomBoosts { get; set; }

        bool Heroes { get; set; }

        string Players { get; set; }

        bool EventDeckClanWar { get; set; }

        bool GivesClanScore { get; set; }

        bool FixedDeckOrder { get; set; }

        bool Heist { get; set; }

        bool SpellSupport { get; set; }

        bool HasDarkElixirCollector { get; set; }
    }
}