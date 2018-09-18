using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.PlayerModels
{
    public class BattleLogTeamCard
    {
        public string Name { get; set; }

        public int? Level { get; set; }

        public int? MaxLevel { get; set; }

        public List<IconUrl> IconUrls { get; set; }
    }
}