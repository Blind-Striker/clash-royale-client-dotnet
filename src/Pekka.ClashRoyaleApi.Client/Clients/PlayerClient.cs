using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class PlayerClient : IPlayerClient
    {
        private readonly IRestApiClient _restApiClient;

        public PlayerClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Player>(UrlPathBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<IApiResponse<List<PlayerBattleLog>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<PlayerBattleLog>>(UrlPathBuilder.GetBattlelogUrl(playerTag));

            return apiResponse;
        }

        public async Task<IApiResponse<PlayerUpcomingChests>> GetUpcomingChestsResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerUpcomingChests>(UrlPathBuilder.GetUpcomingChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            var apiResponse = await GetPlayerResponseAsync(playerTag);

            return apiResponse.Model;
        }

        public async Task<List<PlayerBattleLog>> GetBattlesAsync(string playerTag)
        {
            var apiResponse = await GetBattlesResponseAsync(playerTag);

            return apiResponse.Model;
        }

        public async Task<PlayerUpcomingChests> GetUpcomingChests(string playerTag)
        {
            var apiResponse = await GetUpcomingChestsResponseAsync(playerTag);

            return apiResponse.Model;
        }
    }
}