using System.Collections.Generic;

namespace RoyaleApi.Client.Models.Clan
{
    public class ClanWarLog
    {
        public int CreatedDate { get; set; }
        public List<ClanWarParticipant> Participants { get; set; }
        public List<ClanWarInfoClan> Standings { get; set; }
        public int SeasonNumber { get; set; }
    }
}