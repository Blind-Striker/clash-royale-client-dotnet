using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.TournamentModels;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ITournamentClient : ITournamentClientWithApiResponse, ITournamentClientModel
    {
    }

    public interface ITournamentClientWithApiResponse
    {
        Task<IApiResponse<PagedTournaments>> SearchTournamentResponseAsync(TournamentFilter tournamentFilter);

        Task<IApiResponse<Tournament>> GetTournamentResponseAsync(string tournamentTag);
    }

    public interface ITournamentClientModel
    {
        Task<PagedTournaments> SearchTournamentAsync(TournamentFilter tournamentFilter);

        Task<Tournament> GetTournamentAsync(string tournamentTag);
    }
}