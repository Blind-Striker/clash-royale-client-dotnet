using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core.Contracts;
using Pekka.Core.Exceptions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class PlayerClient : IPlayerClient
    {
        private readonly IRestApiClient _restApiClient;

        public PlayerClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Player>(UrlPathBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.GetPlayerUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerChest>(UrlPathBuilder.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerChest>>(UrlPathBuilder.GetPlayerChestsUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            string urlPath = UrlPathBuilder.GetTopPlayersUrl(location);

            var queryParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("max", max.ToString()),
                new KeyValuePair<string, string>("page", page.ToString())
            };

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerSummary>>(urlPath, queryParams);

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync()
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.PopularPlayersUrl);

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetPlayerResponseAsync(playerTag);

            return response.GetModel();
        }

        public async Task<List<Player>> GetPlayersAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetPlayersResponseAsync(playerTags);

            return response.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetBattlesResponseAsync(playerTag);

            return response.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetBattlesResponseAsync(playerTags);

            return response.GetModel();
        }

        public async Task<PlayerChest> GetChestAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetChestResponseAsync(playerTag);

            return response.GetModel();
        }

        public async Task<List<PlayerChest>> GetChestsAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetChestsResponseAsync(playerTags);

            return response.GetModel();
        }

        public async Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            var response = await GetTopPlayersResponseAsync(location, max, page);

            return response.GetModel();
        }

        public async Task<List<Player>> GetPopularPlayersAsync()
        {
            var response = await GetPopularPlayersResponseAsync();

            return response.GetModel();
        }
    }
}
