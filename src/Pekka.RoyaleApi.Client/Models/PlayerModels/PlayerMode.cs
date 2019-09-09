namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    public class PlayerMode
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CardLevelAdjustment { get; set; }

        public string DeckSelection { get; set; }

        public int OvertimeSeconds { get; set; }

        public bool SameDeckOnBoth { get; set; }

        public bool SeparateTeamDecks { get; set; }

        public bool SwappingTowers { get; set; }

        public bool UseStartingElixir { get; set; }

        public bool RandomBoosts { get; set; }

        public bool Heroes { get; set; }

        public string Players { get; set; }

        public bool EventDeckClanWar { get; set; }

        public bool GivesClanScore { get; set; }

        public bool FixedDeckOrder { get; set; }

        public bool Heist { get; set; }

        public bool SpellSupport { get; set; }

        public bool HasDarkElixirCollector { get; set; }

        public override string ToString()
        {
            return $"{Name}-{Id}";
        }
    }
}