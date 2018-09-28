using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models.TournamentModels;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface ITournamentClient : ITournamentClientWithApiResponse, ITournamentClientWithModel
    {

    }

    public interface ITournamentClientWithApiResponse
    {
        Task<ApiResponse<List<Tournament>>> SearchTournamentResponseAsync(TournamentSearchFilter tournamentSearchFilter = null);
        Task<ApiResponse<List<Tournament>>> GetTournamentsResponseAsync(string[] tournamentTags, TournamentSearchFilter tournamentSearchFilter = null);
        Task<ApiResponse<List<Tournament>>> GetOpenTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> GetKnownTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> Get1KTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> GetInPrepTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> GetFullTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> GetJoinableTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
        Task<ApiResponse<List<Tournament>>> GetPopularTournamentsResponseAsync(TournamentFilter tournamentFilter = null);
    }

    public interface ITournamentClientWithModel
    {
        Task<List<Tournament>> SearchTournamentAsync(TournamentSearchFilter tournamentSearchFilter = null);
        Task<List<Tournament>> GetTournamentsAsync(string[] tournamentTags, TournamentSearchFilter tournamentSearchFilter = null);
        Task<List<Tournament>> GetOpenTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> GetKnownTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> Get1KTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> GetInPrepTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> GetFullTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> GetJoinableTournamentsAsync(TournamentFilter tournamentFilter = null);
        Task<List<Tournament>> GetPopularTournamentsAsync(TournamentFilter tournamentFilter = null);
    }
}