using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
    public class ConstantCardsStats
    {
        public ConstantTroop[] Troop { get; set; }

        public ConstantBuilding[] Building { get; set; }

        public ConstantSpell[] Spell { get; set; }
    }
}