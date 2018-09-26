using Pekka.Core;
using Pekka.RoyaleApi.Client.Models.TournamentModels;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class TournamentSearchFilter : BaseFilter<Tournament>
    {
        [Query("name")]
        public string Name { get; set; }
    }
}