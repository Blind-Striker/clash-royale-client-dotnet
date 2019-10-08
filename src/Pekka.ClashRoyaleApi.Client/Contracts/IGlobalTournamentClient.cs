using Pekka.Core.Responses;

using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IGlobalTournamentClient : IGlobalTournamentClientWithResponse, IGlobalTournamentClientWithModel
    {
    }

    public interface IGlobalTournamentClientWithModel
    {
        Task<PagedGlobalTournaments> GetGlobalTournamentsAsync();
    }

    public interface IGlobalTournamentClientWithResponse
    {
        Task<IApiResponse<PagedGlobalTournaments>> GetGlobalTournamentsResponseAsync();
    }
}