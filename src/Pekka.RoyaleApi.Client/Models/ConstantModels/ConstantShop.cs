using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantShop
    {
        public string Name { get; set; }

        //public object BaseChest { get; set; }
        public ConstantArenaReward Arena { get; set; }

        public bool InShop { get; set; }

        public bool InArenaInfo { get; set; }

        public bool TournamentChest { get; set; }

        public bool SurvivalChest { get; set; }

        public int ShopPriceWithoutSpeedUp { get; set; }

        public int TimeTakenDays { get; set; }

        public int TimeTakenHours { get; set; }

        public int TimeTakenMinutes { get; set; }

        public int TimeTakenSeconds { get; set; }

        public int RandomSpells { get; set; }

        public int DifferentSpells { get; set; }

        public int ChestCountInChestCycle { get; set; }

        public int RareChance { get; set; }

        public int EpicChance { get; set; }

        public int LegendaryChance { get; set; }

        public int SkinChance { get; set; }

        //public object GuaranteedSpells { get; set; }
        public int MinGoldPerCard { get; set; }

        public int MaxGoldPerCard { get; set; }

        //public object SpellSet { get; set; }
        public int Exp { get; set; }

        public int SortValue { get; set; }

        public bool SpecialOffer { get; set; }

        public bool DraftChest { get; set; }

        public bool BoostedChest { get; set; }

        public int LegendaryOverrideChance { get; set; }

        public string Description { get; set; }

        public int CardCount { get; set; }

        public int MinGold { get; set; }

        public int MaxGold { get; set; }

        public ConstantArenaReward[] Arenas { get; set; }
    }
}