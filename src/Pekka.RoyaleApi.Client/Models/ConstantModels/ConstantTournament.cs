using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Models.ConstantModels
{
    public class ConstantTournament
    {
        public int CreateCost { get; set; }

        public int MaxPlayers { get; set; }

        public string Key { get; set; }

        public List<ConstantPrize> Prizes { get; set; }

        public List<int> Cards { get; set; }
    }
}