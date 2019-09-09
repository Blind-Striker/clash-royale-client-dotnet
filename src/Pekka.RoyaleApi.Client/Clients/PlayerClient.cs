using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
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

        public async Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag, PlayerFilter playerFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Player>(UrlPathBuilder.GetPlayerUrl(playerTag), playerFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, PlayerFilter playerFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.GetPlayerUrl(playerTags), playerFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTag), playerBattleFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Battle>>(UrlPathBuilder.GetPlayerBattlesUrl(playerTags), playerBattleFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag, PlayerChestFilter playerChestFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerChest>(UrlPathBuilder.GetPlayerChestsUrl(playerTag), playerChestFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, PlayerChestFilter playerChestFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerChest>>(UrlPathBuilder.GetPlayerChestsUrl(playerTags), playerChestFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerSummary>>(UrlPathBuilder.GetTopPlayersUrl(location), playerSummaryFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<List<Player>>> GetPopularPlayersResponseAsync(PlayerFilter playerFilter = null)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<List<Player>>(UrlPathBuilder.PopularPlayersUrl, playerFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag, PlayerFilter playerFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetPlayerResponseAsync(playerTag, playerFilter);

            return response.Model;
        }

        public async Task<List<Player>> GetPlayersAsync(string[] playerTags, PlayerFilter playerFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetPlayersResponseAsync(playerTags, playerFilter);

            return response.Model;
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetBattlesResponseAsync(playerTag, playerBattleFilter);

            return response.Model;
        }

        public async Task<List<Battle>> GetBattlesAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetBattlesResponseAsync(playerTags, playerBattleFilter);

            return response.Model;
        }

        public async Task<PlayerChest> GetChestAsync(string playerTag, PlayerChestFilter playerChestFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var response = await GetChestResponseAsync(playerTag, playerChestFilter);

            return response.Model;
        }

        public async Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, PlayerChestFilter playerChestFilter)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playerTags, nameof(playerTags));

            var response = await GetChestsResponseAsync(playerTags, playerChestFilter);

            return response.Model;
        }

        public async Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null)
        {
            var response = await GetTopPlayersResponseAsync(location, playerSummaryFilter);

            return response.Model;
        }

        public async Task<List<Player>> GetPopularPlayersAsync(PlayerFilter playerFilter = null)
        {
            var response = await GetPopularPlayersResponseAsync(playerFilter);

            return response.Model;
        }
    }
}
