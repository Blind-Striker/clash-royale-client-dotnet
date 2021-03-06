﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantCard
    {
        public string Key { get; set; }

        public string Name { get; set; }

        public int Elixir { get; set; }

        public string Type { get; set; }

        public string Rarity { get; set; }

        public int Arena { get; set; }

        public string Description { get; set; }

        public int Id { get; set; }
    }
}