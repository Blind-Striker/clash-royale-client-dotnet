using Pekka.ClashRoyaleApi.Client.Contracts.Models;

namespace Pekka.ClashRoyaleApi.Client.Models.ClanModels
{
    public class PagedClanWarLogs : IPaged<ClanWarLog>
    {
        public ClanWarLog[] Items { get; set; }

        public Paging Paging { get; set; }
    }
}