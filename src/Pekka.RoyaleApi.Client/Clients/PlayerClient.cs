using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;
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

        public async Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.GetPlayerUrl(playerTags), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTag), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTags), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerChest>(UrlPathBuilder.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerChest>>(UrlPathBuilder.GetPlayerChestsUrl(playerTags), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerSummary>>(UrlPathBuilder.GetTopPlayersUrl(location), pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync(Pagination pagination = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.PopularPlayersUrl, pagination?.ToQueryParams());

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetPlayerResponseAsync(playerTag);

            return response.GetModel();
        }

        public async Task<List<Player>> GetPlayersAsync(string[] playerTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetPlayersResponseAsync(playerTags, pagination);

            return response.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetBattlesResponseAsync(playerTag, pagination);

            return response.GetModel();
        }

        public async Task<List<Battle>> GetBattlesAsync(string[] playerTags, Pagination pagination = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetBattlesResponseAsync(playerTags, pagination);

            return response.GetModel();
        }

        public async Task<PlayerChest> GetChestAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetChestResponseAsync(playerTag);

            return response.GetModel();
        }

        public async Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, Pagination pagination)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetChestsResponseAsync(playerTags, pagination);

            return response.GetModel();
        }

        public async Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, Pagination pagination = null)
        {
            var response = await GetTopPlayersResponseAsync(location, pagination);

            return response.GetModel();
        }

        public async Task<List<Player>> GetPopularPlayersAsync(Pagination pagination = null)
        {
            var response = await GetPopularPlayersResponseAsync(pagination);

            return response.GetModel();
        }
    }
}
