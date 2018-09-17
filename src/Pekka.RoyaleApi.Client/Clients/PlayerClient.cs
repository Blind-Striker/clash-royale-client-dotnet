using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Helpers;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.Player;
using Pekka.RoyaleApi.Client.Responses;

namespace Pekka.RoyaleApi.Client.Clients
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

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Player>(UrlBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Player>>(UrlBuilder.GetPlayerUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(UrlBuilder.GetPlayerBattlesUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(UrlBuilder.GetPlayerBattlesUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<PlayerChest>(UrlBuilder.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<PlayerChest>>(UrlBuilder.GetPlayerChestsUrl(playerTags));

            return apiResponse;
        }

        public async Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<PlayerSummary>>(UrlBuilder.GetTopPlayersUrl(location, max, page));

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync()
        {
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Player>>(UrlBuilder.PopularPlayersUrl);

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<Player>(UrlBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<Player>> GetPlayersAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Player>>(UrlBuilder.GetPlayerUrl(playerTags));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(UrlBuilder.GetPlayerBattlesUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(UrlBuilder.GetPlayerBattlesUrl(playerTags));

            return apiResponse;
        }

        public async Task<PlayerChest> GetChestAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _royaleApiClient.GetAsync<PlayerChest>(UrlBuilder.GetPlayerChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<List<PlayerChest>> GetChestsAsync(params string[] playerTags)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _royaleApiClient.GetAsync<List<PlayerChest>>(UrlBuilder.GetPlayerChestsUrl(playerTags));

            return apiResponse;
        }

        public async Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, int max = 10, int page = 0)
        {
            var apiResponse = await _royaleApiClient.GetAsync<List<PlayerSummary>>(UrlBuilder.GetTopPlayersUrl(location, max, page));

            return apiResponse;
        }

        public async Task<List<Player>> GetPopularPlayersAsync()
        {
            var apiResponse = await _royaleApiClient.GetAsync<List<Player>>(UrlBuilder.PopularPlayersUrl);

            return apiResponse;
        }
    }
}
