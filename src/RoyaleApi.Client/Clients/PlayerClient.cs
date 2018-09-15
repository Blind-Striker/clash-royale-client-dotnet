using System.Collections.Generic;
using System.Threading.Tasks;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Helpers;
using RoyaleApi.Client.Models;

namespace RoyaleApi.Client.Clients
{
    public class PlayerClient : IPlayerClient
    {
        private const string PlayerUrl = "player";
        private const string BattlesUrl = "battles";
        private const string ChestsUrl = "chests";

        private readonly IRoyaleApiClient _royaleApiClient;

        private readonly string _playerTemplate = $"{PlayerUrl}/{{0}}";
        private readonly string _battlesTemplate = $"{PlayerUrl}/{{0}}/{BattlesUrl}";
        private readonly string _chestsTemplate = $"{PlayerUrl}/{{0}}/{ChestsUrl}";

        public PlayerClient(IRoyaleApiClient royaleApiClient)
        {
            _royaleApiClient = royaleApiClient;
        }

        public async Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_playerTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Player>(url);

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_playerTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetAsync<Player>(url);

            return apiResponse;
        }

        public async Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_playerTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Player>>(url);

            return apiResponse;
        }

        public async Task<List<Player>> GetPlayersAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_playerTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetAsync<List<Player>>(url);

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_battlesTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(url);

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_battlesTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(url);

            return apiResponse;
        }

        public async Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_battlesTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Battle>>(url);

            return apiResponse;
        }

        public async Task<List<Battle>> GetBattlesAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_battlesTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetAsync<List<Battle>>(url);

            return apiResponse;
        }

        public async Task<ApiResponse<Chest>> GetChestResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_battlesTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<Chest>(url);

            return apiResponse;
        }

        public async Task<Chest> GetChestAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var url = string.Format(_battlesTemplate, playerTag);
            var apiResponse = await _royaleApiClient.GetAsync<Chest>(url);

            return apiResponse;
        }

        public async Task<ApiResponse<List<Chest>>> GetChestsResponseAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_chestsTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetApiResponseAsync<List<Chest>>(url);

            return apiResponse;
        }

        public async Task<List<Chest>> GetChestsAsync(params string[] playersTag)
        {
            Ensure.ArgumentNotNullOrEmptyEnumerable(playersTag, nameof(playersTag));

            var url = string.Format(_chestsTemplate, playersTag.JoinToString(","));
            var apiResponse = await _royaleApiClient.GetAsync<List<Chest>>(url);

            return apiResponse;
        }
    }
}
