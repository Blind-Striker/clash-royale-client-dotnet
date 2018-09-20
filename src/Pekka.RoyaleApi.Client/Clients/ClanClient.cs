using System;
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

        public async Task<ApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.ClanSearchUrl, clanFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetClansResponseAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.GetClanUrl(clanTags));

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

        public async Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanWar>(UrlPathBuilder.GetClanWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanTracking>(UrlPathBuilder.GetClanTrackingUrl(clanTag));

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

        public async Task<ApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.GetTopClansUrl(location), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(Pagination pagination = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.PopularClansUrl, pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanSummary>>> GetGetTopWarClanWarsResponseAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.GetTopWarClanWarsUrl(location), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<List<ClanSummary>> SearchClanAsync(ClanFilter clanFilter = null)
        {
            var apiResponse = await SearchClanResponseAsync(clanFilter);

            return apiResponse.GetModel();
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetClanResponseAsync(clanTag);

            return apiResponse.GetModel();
        }

        public async Task<List<Clan>> GetClansAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await GetClansResponseAsync(clanTags);

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

        public async Task<ClanWar> GetWarAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarResponseAsync(clanTag);

            return apiResponse.GetModel();
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetTrackingResponseAsync(clanTag);

            return apiResponse.GetModel();
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            var apiResponse = await GetClanHistoryDailyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.GetModel();
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            var apiResponse = await GetClanHistoryWeeklyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanSummary>> GetTopClanAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var apiResponse = await GetTopClansResponseAsync(location, pagination);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanSummary>> GetGetTopWarClanWarsAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var apiResponse = await GetGetTopWarClanWarsResponseAsync(location, pagination);

            return apiResponse.GetModel();
        }

        public async Task<List<Clan>> GetPopularClanAsync(Pagination pagination = null)
        {
            var apiResponse = await GetPopularPlayersResponseAsync(pagination);

            return apiResponse.GetModel();
        }
    }
}
