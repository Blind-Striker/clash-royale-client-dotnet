using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class CurrentWar
    {
        public string State { get; set; }

        public string WarEndTime { get; set; }

        public CurrentWarClan Clan { get; set; }

        public List<WarParticipant> Participants { get; set; }
    }
}