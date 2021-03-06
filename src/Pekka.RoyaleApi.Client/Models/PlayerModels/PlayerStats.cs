﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.PlayerModels
{
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class PlayerStats
    {
        public int ClanCardsCollected { get; set; }

        public int TournamentCardsWon { get; set; }

        public int MaxTrophies { get; set; }

        public int ThreeCrownWins { get; set; }

        public int CardsFound { get; set; }

        public PlayerCard FavoriteCard { get; set; }

        public int TotalDonations { get; set; }

        public int ChallengeMaxWins { get; set; }

        public int ChallengeCardsWon { get; set; }

        public int Level { get; set; }
    }
}