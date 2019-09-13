//using Pekka.Core.Contracts;
//using Pekka.Core.Extensions;
//using Pekka.Core.Helpers;
//using Pekka.Core.Responses;
//using Pekka.RoyaleApi.Client.Contracts;
//using Pekka.RoyaleApi.Client.FilterModels;
//using Pekka.RoyaleApi.Client.Models.TournamentModels;

//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace Pekka.RoyaleApi.Client.Clients
//{
//    public class TournamentClient : ITournamentClient
//    {
//        private readonly IRestApiClient _restApiClient;

//        public TournamentClient(IRestApiClient restApiClient)
//        {
//            _restApiClient = restApiClient;
//        }

//        public async Task<IApiResponse<List<Tournament>>> SearchTournamentResponseAsync(
//            TournamentSearchFilter tournamentSearchFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.TournamentSearchUrl,
//                    tournamentSearchFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetTournamentsResponseAsync(string[] tournamentTags,
//            TournamentSearchFilter tournamentSearchFilter = null)
//        {
//            Ensure.ArgumentNotNullOrEmptyEnumerable(tournamentTags, nameof(tournamentTags));

//            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Tournament>>(
//                UrlPathBuilder.GetTournamentUrl(tournamentTags), tournamentSearchFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetOpenTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.OpenTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetKnownTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.KnownTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> Get1KTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.OneKTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetInPrepTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.InPrepTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetFullTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.FullTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetJoinableTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.JoinableTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<IApiResponse<List<Tournament>>> GetPopularTournamentsResponseAsync(
//            TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse =
//                await _restApiClient.GetApiResponseAsync<List<Tournament>>(UrlPathBuilder.PopularTournamentUrl,
//                    tournamentFilter?.ToQueryParams());

//            return apiResponse;
//        }

//        public async Task<List<Tournament>> SearchTournamentAsync(TournamentSearchFilter tournamentSearchFilter = null)
//        {
//            var apiResponse = await SearchTournamentResponseAsync(tournamentSearchFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetTournamentsAsync(string[] tournamentTags,
//            TournamentSearchFilter tournamentSearchFilter = null)
//        {
//            var apiResponse = await GetTournamentsResponseAsync(tournamentTags, tournamentSearchFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetOpenTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetOpenTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetKnownTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetKnownTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> Get1KTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await Get1KTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetInPrepTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetInPrepTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetFullTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetFullTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetJoinableTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetJoinableTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }

//        public async Task<List<Tournament>> GetPopularTournamentsAsync(TournamentFilter tournamentFilter = null)
//        {
//            var apiResponse = await GetPopularTournamentsResponseAsync(tournamentFilter);

//            return apiResponse.Model;
//        }
//    }
//}