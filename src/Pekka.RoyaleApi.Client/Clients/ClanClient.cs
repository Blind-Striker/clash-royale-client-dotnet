using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
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

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            string urlPath = UrlPathBuilder.GetClanBattleUrl(clanTag);

            IList<KeyValuePair<string, string>> queryParams = null;

            if (clanBattleType != null)
            {
                queryParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("type", clanBattleType.ToString()),
                };
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(urlPath, queryParams);

            return apiResponse;
        }

        public async Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<ClanWarLog>>(UrlPathBuilder.GetClanWarLogUrl(clanTag));

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

        public async Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleType clanBattleType = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetBattlesResponseAsync(clanTag);

            return apiResponse.GetModel();
        }

        public async Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await GetWarLogsResponseAsync(clanTag);

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
    }
}
