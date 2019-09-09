﻿using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    public class Constants
    {
        public List<ConstantAllianceBadge> AllianceBadges { get; set; }

        public List<ConstantArena> Arenas { get; set; }

        public List<Card> Cards { get; set; }

        public ConstantCardsStats CardsStats { get; set; }

        public List<ConstantChallenge> Challenges { get; set; }

        public ConstantChestOrder ChestOrder { get; set; }

        public ConstantClanChest ClanChest { get; set; }

        public List<ConstantGameMode> GameModes { get; set; }

        public List<ConstantRarity> Rarities { get; set; }

        public List<ConstantRegion> Regions { get; set; }

        public List<ConstantTournament> Tournaments { get; set; }

        public ConstantTreasureChests TreasureChests { get; set; }
    }
}