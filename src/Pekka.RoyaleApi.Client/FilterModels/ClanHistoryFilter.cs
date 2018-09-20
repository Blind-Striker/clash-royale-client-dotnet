using Pekka.Core;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class ClanHistoryFilter : Pagination
    {
        [Query("days")]
        public int Days { get; set; }
    }
}
