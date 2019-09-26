using System.Collections.Generic;
using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IGlobalTournamentClient : IGlobalTournamentClientWithResponse, IGlobalTournamentClientWithModel
    {
    }

    public interface IGlobalTournamentClientWithModel
    {
        Task<List<Card>> GetGlobalTournamentsAsync();
    }

    public interface IGlobalTournamentClientWithResponse
    {
        Task<IApiResponse<List<Card>>> GetGlobalTournamentsResponseAsync();
    }
}