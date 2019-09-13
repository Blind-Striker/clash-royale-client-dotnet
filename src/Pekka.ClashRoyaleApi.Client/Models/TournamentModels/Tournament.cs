using System.Collections.Generic;

namespace Pekka.ClashRoyaleApi.Client.Models.TournamentModels
{
    public class Tournament
    {
        public List<TournamentBaseItem> Items { get; set; }

        public string StartedTime { get; set; }

        public List<TournamentMembersList> MembersList { get; set; }
    }
}