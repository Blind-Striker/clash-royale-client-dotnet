using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IClanSummary
    {
        string Tag { get; set; }

        string Name { get; set; }

        string Type { get; set; }

        int Score { get; set; }

        int MemberCount { get; set; }

        int RequiredScore { get; set; }

        int Donations { get; set; }

        ClanBadge Badge { get; set; }

        ClanLocation Location { get; set; }

        ClanTracking Tracking { get; set; }
    }
}