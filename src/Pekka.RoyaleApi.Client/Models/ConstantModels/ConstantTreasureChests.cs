using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantTreasureChests
    {
        public List<ConstantCycle> Cycle { get; set; }

        public List<ConstantCrown> Crown { get; set; }

        public List<ConstantShop> Shop { get; set; }
    }
}