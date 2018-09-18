using Pekka.ClashRoyaleApi.Client.Models.ClanModels;

namespace Pekka.ClashRoyaleApi.Client.Models.TournamentModels
{
    public class TournamentMembersList
    {
        public string Tag { get; set; }

        public string Name { get; set; }

        public int? Score { get; set; }

        public int? Rank { get; set; }

        public ClanBase Clan { get; set; }
    }
}