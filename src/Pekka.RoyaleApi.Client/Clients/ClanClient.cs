using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Helpers;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.Clan;
using Pekka.RoyaleApi.Client.Responses;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class ClanClient : IClanClient
    {
        private readonly IRoyaleApiClient _royaleApiClient;

        public ClanClient(IRoyaleApiClient royaleApiClient)
        {
            _royaleApiClient = royaleApiClient;
        }

        public async Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Clan>(UrlBuilder.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetClansResponseAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Clan>>(UrlBuilder.GetClanUrl(clanTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(UrlBuilder.GetClanBattleUrl(clanBattleType, clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<ClanWarLog>>(UrlBuilder.GetClanWarLogUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<ClanWar>(UrlBuilder.GetClanWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<ClanTracking>(UrlBuilder.GetClanTrackingUrl(clanTag));

            return apiResponse;
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<Clan>(UrlBuilder.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<List<Clan>> GetClansAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Clan>>(UrlBuilder.GetClanUrl(clanTags));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(UrlBuilder.GetClanBattleUrl(clanBattleType, clanTag));

            return apiResponse;
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<ClanWarLog>>(UrlBuilder.GetClanWarLogUrl(clanTag));

            return apiResponse;
        }

        public async Task<ClanWar> GetWarAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<ClanWar>(UrlBuilder.GetClanWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<ClanTracking>(UrlBuilder.GetClanTrackingUrl(clanTag));

            return apiResponse;
        }
    }
}
