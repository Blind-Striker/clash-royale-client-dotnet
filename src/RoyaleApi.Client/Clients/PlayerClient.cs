using System.Collections.Generic;
using System.Threading.Tasks;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Helpers;
using RoyaleApi.Client.Models;
using RoyaleApi.Client.Models.Player;
using RoyaleApi.Client.Responses;

namespace RoyaleApi.Client.Clients
{
    public class PlayerClient : IPlayerClient
    {
        private readonly IRoyaleApiClient _royaleApiClient;

        public PlayerClient(IRoyaleApiClient royaleApiClient)
        {
            _royaleApiClient = royaleApiClient;
        }

        public async Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Player>(Endpoints.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Player>>(Endpoints.GetPlayerUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(Endpoints.GetPlayerBattlesUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(Endpoints.GetPlayerBattlesUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<PlayerChest>(Endpoints.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<PlayerChest>>(Endpoints.GetPlayerChestsUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<PlayerSummary>>(Endpoints.GetTopPlayersUrl(location, max, page));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync()
        {
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Player>>(Endpoints.PopularPlayersUrl);

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<Player>(Endpoints.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<Player>> GetPlayersAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Player>>(Endpoints.GetPlayerUrl(playerTags));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(Endpoints.GetPlayerBattlesUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(Endpoints.GetPlayerBattlesUrl(playerTags));

            return apiResponse;
        }

        public async Task<PlayerChest> GetChestAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<PlayerChest>(Endpoints.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<PlayerChest>> GetChestsAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<PlayerChest>>(Endpoints.GetPlayerChestsUrl(playerTags));

            return apiResponse;
        }

        public async Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            var apiResponse = await _royaleApiClient.GetAsync<List<PlayerSummary>>(Endpoints.GetTopPlayersUrl(location, max, page));

            return apiResponse;
        }

        public async Task<List<Player>> GetPopularPlayersAsync()
        {
            var apiResponse = await _royaleApiClient.GetAsync<List<Player>>(Endpoints.PopularPlayersUrl);

            return apiResponse;
        }
    }
}
