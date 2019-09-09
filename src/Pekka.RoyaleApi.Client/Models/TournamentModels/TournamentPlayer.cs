using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.Models.TournamentModels
{
    public class TournamentPlayer
    {
        public string Tag { get; set; }

        public PlayerClanInfo Clan { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public int Score { get; set; }

        public bool Creator { get; set; }
    }
}