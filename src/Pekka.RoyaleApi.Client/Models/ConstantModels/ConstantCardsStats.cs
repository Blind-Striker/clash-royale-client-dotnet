using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    public class ConstantCardsStats
    {
        public List<ConstantTroop> Troop { get; set; }

        public List<ConstantBuilding> Building { get; set; }

        public List<ConstantSpell> Spell { get; set; }
    }
}