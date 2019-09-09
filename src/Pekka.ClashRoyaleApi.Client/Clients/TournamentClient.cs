using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.TournamentModels;
using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using System;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class TournamentClient : ITournamentClient
    {
        private readonly IRestApiClient _restApiClient;

        public TournamentClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<IApiResponse<TournamentSearchResult>> SearchTournamentResponseAsync(TournamentFilter tournamentFilter)
        {
            Ensure.ArgumentNotNull(tournamentFilter, nameof(tournamentFilter));
            Ensure.AtleastOneCriteriaMustBeDefined(tournamentFilter, nameof(tournamentFilter));

            if (tournamentFilter?.Name != null && tournamentFilter.Name.Length < 3)
            {
                throw new ArgumentException("Name needs to be at least three characters long.", nameof(TournamentFilter.Name));
            }

            if (tournamentFilter?.After != null && tournamentFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<TournamentSearchResult>(UrlPathBuilder.TournamentUrl, tournamentFilter.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Tournament>> GetTournamentResponseAsync(string tournamentTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(tournamentTag, nameof(tournamentTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Tournament>(UrlPathBuilder.GetTournamentUrl(tournamentTag));

            return apiResponse;
        }

        public async Task<TournamentSearchResult> SearchTournamentAsync(TournamentFilter tournamentFilter)
        {
            var apiResponse = await SearchTournamentResponseAsync(tournamentFilter);

            return apiResponse.Model;
        }

        public async Task<Tournament> GetTournamentAsync(string tournamentTag)
        {
            var apiResponse = await GetTournamentResponseAsync(tournamentTag);

            return apiResponse.Model;
        }
    }
}