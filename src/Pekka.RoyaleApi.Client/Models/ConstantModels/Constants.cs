using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class Constants
    {
        public ConstantAllianceBadge[] AllianceBadges { get; set; }

        public ConstantArena[] Arenas { get; set; }

        public ConstantCard[] Cards { get; set; }

        public ConstantCardsStats CardsStats { get; set; }

        public ConstantChallenge[] Challenges { get; set; }

        public ConstantChestOrder ChestOrder { get; set; }

        public ConstantClanChest ClanChest { get; set; }

        public ConstantGameMode[] GameModes { get; set; }

        public ConstantRarity[] Rarities { get; set; }

        public ConstantRegion[] Regions { get; set; }

        public ConstantTournament[] Tournaments { get; set; }

        public ConstantTreasureChests TreasureChests { get; set; }
    }
}