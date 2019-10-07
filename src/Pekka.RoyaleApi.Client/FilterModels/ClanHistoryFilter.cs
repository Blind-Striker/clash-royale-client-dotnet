using Pekka.Core.Attributes;
using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class ClanHistoryFilter : BaseFilter<ClanHistory>
    {
        [Query("days")]
        public int Days { get; set; }
    }
}