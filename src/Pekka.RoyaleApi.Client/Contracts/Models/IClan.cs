using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.Contracts.Models
{
    public interface IClan : IClanSummary
    {
        string Description { get; set; }

        int WarTrophies { get; set; }

        ClanMember[] Members { get; set; }
    }
}