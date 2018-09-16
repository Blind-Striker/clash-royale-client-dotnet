using System.Collections.Generic;
using System.Threading.Tasks;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Helpers;
using RoyaleApi.Client.Models;
using RoyaleApi.Client.Models.Clan;
using RoyaleApi.Client.Responses;

namespace RoyaleApi.Client.Clients
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

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Clan>(Endpoints.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Clan>>> GetClansResponseAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Clan>>(Endpoints.GetClanUrl(clanTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(Endpoints.GetClanBattleUrl(clanBattleType, clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<ClanWarLog>>(Endpoints.GetClanWarLogUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<ClanWar>(Endpoints.GetClanWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<ClanTracking>(Endpoints.GetClanTrackingUrl(clanTag));

            return apiResponse;
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<Clan>(Endpoints.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<List<Clan>> GetClansAsync(params string[] clanTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(clanTags, nameof(clanTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Clan>>(Endpoints.GetClanUrl(clanTags));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(Endpoints.GetClanBattleUrl(clanBattleType, clanTag));

            return apiResponse;
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<ClanWarLog>>(Endpoints.GetClanWarLogUrl(clanTag));

            return apiResponse;
        }

        public async Task<ClanWar> GetWarAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<ClanWar>(Endpoints.GetClanWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ClanTracking> GetTrackingAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _royaleApiClient.GetAsync<ClanTracking>(Endpoints.GetClanTrackingUrl(clanTag));

            return apiResponse;
        }
    }
}
