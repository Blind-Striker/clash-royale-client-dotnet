using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantCardsStats
    {
        public List<ConstantTroop> Troop { get; set; }

        public List<ConstantBuilding> Building { get; set; }

        public List<ConstantSpell> Spell { get; set; }
    }
}