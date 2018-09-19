using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class ClanClient : IClanClient
    {
        private readonly IRestApiClient _restApiClient;

        public ClanClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<ApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.ClanSearchUrl, clanFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.GetClanUrl(clanTags), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetClanBattleUrl(clanTag), clanBattleFilter.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanWarLog>>(UrlPathBuilder.GetClanWarLogUrl(clanTag), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanWar>(UrlPathBuilder.GetClanWarUrl(clanTag), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanTracking>(UrlPathBuilder.GetClanTrackingUrl(clanTag), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<List<ClanSummary>> SearchClanAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await SearchClanResponseAsync(clanFilter);

            return apiResponse.GetModel();
        }

        public async Task<Clan> GetClanAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetClanResponseAsync(clanTag, pagination);

            return apiResponse.GetModel();
        }

        public async Task<List<Clan>> GetClansAsync(string[] clanTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await GetClansResponseAsync(clanTags, pagination);

            return apiResponse.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetBattlesResponseAsync(clanTag, clanBattleFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarLogsResponseAsync(clanTag, pagination);

            return apiResponse.GetModel();
        }

        public async Task<ClanWar> GetWarAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarResponseAsync(clanTag, pagination);

            return apiResponse.GetModel();
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetTrackingResponseAsync(clanTag, pagination);

            return apiResponse.GetModel();
        }
    }
}
