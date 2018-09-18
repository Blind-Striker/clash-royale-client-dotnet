using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class WarLogItem
    {
        public int? SeasonId { get; set; }

        public string CreatedDate { get; set; }

        public List<WarParticipant> Participants { get; set; }
    }
}
