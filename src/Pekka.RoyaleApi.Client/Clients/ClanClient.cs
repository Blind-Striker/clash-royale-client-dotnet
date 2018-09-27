using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core;
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

        public async Task<ApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.ClanSearchUrl, clanSummaryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag), clanFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.GetClanUrl(clanTags), clanFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetClanBattleUrl(clanTag), clanBattleFilter.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanWarLog>>(UrlPathBuilder.GetClanWarLogUrl(clanTag), clanWarLogFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, ClanWarFilter clanWarFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanWar>(UrlPathBuilder.GetClanWarUrl(clanTag), clanWarFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanTracking>(UrlPathBuilder.GetClanTrackingUrl(clanTag), clanTrackingFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryDailyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Dictionary<string, ClanHistory>>(
                UrlPathBuilder.GetClanHistoryDailyUrl(clanTag), clanHistoryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryWeeklyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Dictionary<string, ClanHistory>>(
                UrlPathBuilder.GetClanHistoryWeeklyUrl(clanTag), clanHistoryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.GetTopClansUrl(location), clanSummaryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.PopularClansUrl, clanFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanSummary>>> GetTopWarClanWarsResponseAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.GetTopWarClanWarsUrl(location), clanSummaryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<List<ClanSummary>> SearchClanAsync(ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await SearchClanResponseAsync(clanSummaryFilter);

            return apiResponse.GetModel();
        }

        public async Task<Clan> GetClanAsync(string clanTag, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetClanResponseAsync(clanTag, clanFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<Clan>> GetClansAsync(string[] clanTags, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await GetClansResponseAsync(clanTags, clanFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetBattlesResponseAsync(clanTag, clanBattleFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarLogsResponseAsync(clanTag, clanWarLogFilter);

            return apiResponse.GetModel();
        }

        public async Task<ClanWar> GetWarAsync(string clanTag, ClanWarFilter clanWarFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarResponseAsync(clanTag, clanWarFilter);

            return apiResponse.GetModel();
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetTrackingResponseAsync(clanTag, clanTrackingFilter);

            return apiResponse.GetModel();
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            var apiResponse = await GetClanHistoryDailyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.GetModel();
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            var apiResponse = await GetClanHistoryWeeklyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanSummary>> GetTopClanAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await GetTopClansResponseAsync(location, clanSummaryFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanSummary>> GetTopWarClanWarsAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null)
        {
            var apiResponse = await GetTopWarClanWarsResponseAsync(location, clanSummaryFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<Clan>> GetPopularClanAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await GetPopularPlayersResponseAsync(clanFilter);

            return apiResponse.GetModel();
        }
    }
}
