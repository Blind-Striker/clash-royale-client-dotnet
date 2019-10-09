using Newtonsoft.Json.Serialization;

using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models.ClanModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class ClanClient : IClanClient
    {
        private readonly IRestApiClient _restApiClient;

        public ClanClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<IApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanSummaryFilter clanSummaryFilter = null)
        {
            IApiResponse<List<ClanSummary>> apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.ClanSearchUrl,
                                                                                                                      clanSummaryFilter?.ToQueryParams(), null,
                                                                                                                      new CamelCaseNamingStrategy());

            return apiResponse;
        }

        public async Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<Clan> apiResponse =
                await _restApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag), clanFilter?.ToQueryParams(), null, new CamelCaseNamingStrategy());

            return apiResponse;
        }

        public async Task<IApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            IApiResponse<List<Clan>> apiResponse = await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.GetClanUrl(clanTags),
                                                                                                        clanFilter?.ToQueryParams(), null, new CamelCaseNamingStrategy());

            return apiResponse;
        }

        public async Task<IApiResponse<List<ClanBattle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<List<ClanBattle>> apiResponse =
                await _restApiClient.GetApiResponseAsync<List<ClanBattle>>(UrlPathBuilder.GetClanBattleUrl(clanTag), clanBattleFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<List<ClanWarLog>> apiResponse =
                await _restApiClient.GetApiResponseAsync<List<ClanWarLog>>(UrlPathBuilder.GetClanWarLogUrl(clanTag), clanWarLogFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, ClanWarFilter clanWarFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<ClanWar> apiResponse = await _restApiClient.GetApiResponseAsync<ClanWar>(UrlPathBuilder.GetClanWarUrl(clanTag), clanWarFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<ClanTracking> apiResponse =
                await _restApiClient.GetApiResponseAsync<ClanTracking>(UrlPathBuilder.GetClanTrackingUrl(clanTag), clanTrackingFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryDailyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<Dictionary<string, ClanHistory>> apiResponse =
                await _restApiClient.GetApiResponseAsync<Dictionary<string, ClanHistory>>(UrlPathBuilder.GetClanHistoryDailyUrl(clanTag),
                                                                                          clanHistoryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryWeeklyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<Dictionary<string, ClanHistory>> apiResponse =
                await _restApiClient.GetApiResponseAsync<Dictionary<string, ClanHistory>>(UrlPathBuilder.GetClanHistoryWeeklyUrl(clanTag),
                                                                                          clanHistoryFilter?.ToQueryParams());

            return apiResponse;
        }

        //public async Task<IApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(LocationsEnum locationEnum = LocationsEnum.None,
        //    ClanSummaryFilter clanSummaryFilter = null)
        //{
        //    var apiResponse =
        //        await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(UrlPathBuilder.GetTopClansUrl(locationEnum),
        //            clanSummaryFilter?.ToQueryParams());

        //    return apiResponse;
        //}

        //public async Task<IApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(ClanFilter clanFilter = null)
        //{
        //    var apiResponse =
        //        await _restApiClient.GetApiResponseAsync<List<Clan>>(UrlPathBuilder.PopularClansUrl,
        //            clanFilter?.ToQueryParams());

        //    return apiResponse;
        //}

        //public async Task<IApiResponse<List<ClanSummary>>> GetTopWarClanWarsResponseAsync(
        //    LocationsEnum locationEnum = LocationsEnum.None, ClanSummaryFilter clanSummaryFilter = null)
        //{
        //    var apiResponse =
        //        await _restApiClient.GetApiResponseAsync<List<ClanSummary>>(
        //            UrlPathBuilder.GetTopWarClanWarsUrl(locationEnum), clanSummaryFilter?.ToQueryParams());

        //    return apiResponse;
        //}

        public async Task<List<ClanSummary>> SearchClanAsync(ClanSummaryFilter clanSummaryFilter = null)
        {
            IApiResponse<List<ClanSummary>> apiResponse = await SearchClanResponseAsync(clanSummaryFilter);

            return apiResponse.Model;
        }

        public async Task<Clan> GetClanAsync(string clanTag, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<Clan> apiResponse = await GetClanResponseAsync(clanTag, clanFilter);

            return apiResponse.Model;
        }

        public async Task<List<Clan>> GetClansAsync(string[] clanTags, ClanFilter clanFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            IApiResponse<List<Clan>> apiResponse = await GetClansResponseAsync(clanTags, clanFilter);

            return apiResponse.Model;
        }

        public async Task<List<ClanBattle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<List<ClanBattle>> apiResponse = await GetBattlesResponseAsync(clanTag, clanBattleFilter);

            return apiResponse.Model;
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<List<ClanWarLog>> apiResponse = await GetWarLogsResponseAsync(clanTag, clanWarLogFilter);

            return apiResponse.Model;
        }

        public async Task<ClanWar> GetWarAsync(string clanTag, ClanWarFilter clanWarFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<ClanWar> apiResponse = await GetWarResponseAsync(clanTag, clanWarFilter);

            return apiResponse.Model;
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<ClanTracking> apiResponse = await GetTrackingResponseAsync(clanTag, clanTrackingFilter);

            return apiResponse.Model;
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            IApiResponse<Dictionary<string, ClanHistory>> apiResponse = await GetClanHistoryDailyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.Model;
        }

        public async Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null)
        {
            IApiResponse<Dictionary<string, ClanHistory>> apiResponse = await GetClanHistoryWeeklyResponseAsync(clanTag, clanHistoryFilter);

            return apiResponse.Model;
        }

        //public async Task<List<ClanSummary>> GetTopClanAsync(LocationsEnum locationEnum = LocationsEnum.None,
        //    ClanSummaryFilter clanSummaryFilter = null)
        //{
        //    var apiResponse = await GetTopClansResponseAsync(locationEnum, clanSummaryFilter);

        //    return apiResponse.Model;
        //}

        //public async Task<List<ClanSummary>> GetTopWarClanWarsAsync(LocationsEnum locationEnum = LocationsEnum.None,
        //    ClanSummaryFilter clanSummaryFilter = null)
        //{
        //    var apiResponse = await GetTopWarClanWarsResponseAsync(locationEnum, clanSummaryFilter);

        //    return apiResponse.Model;
        //}

        //public async Task<List<Clan>> GetPopularClanAsync(ClanFilter clanFilter = null)
        //{
        //    var apiResponse = await GetPopularPlayersResponseAsync(clanFilter);

        //    return apiResponse.Model;
        //}
    }
}