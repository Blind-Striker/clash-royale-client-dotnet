using Pekka.ClashRoyaleApi.Client.Contracts.Models;
using Pekka.ClashRoyaleApi.Client.Models.TournamentModels;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class ClanWarLogs : IPaged<ClanWarLog>
    {
        public ClanWarLog[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}