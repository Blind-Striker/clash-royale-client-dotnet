using Pekka.Core;
using Pekka.Core.Attributes;

namespace Pekka.RoyaleApi.Client.FilterModels
{
    public class TournamentFilter : BaseFilter<TournamentFilter>
    {
        [Query("1k")] public int? OneK { get; set; }

        [Query("open")] public int? Open { get; set; }

        [Query("full")] public int? Full { get; set; }

        [Query("inprep")] public int? InPrep { get; set; }

        [Query("joinable")] public int? Joinable { get; set; }
    }
}