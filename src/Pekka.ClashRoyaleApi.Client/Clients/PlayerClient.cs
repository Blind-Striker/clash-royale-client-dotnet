using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class PlayerClient : IPlayerClient
    {
        private readonly IRestApiClient _restApiClient;

        public PlayerClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<ApiResponse<PlayerDetail>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerDetail>(UrlPathBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<List<BattleLog>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<List<BattleLog>>(UrlPathBuilder.GetBattlelogUrl(playerTag));

            return apiResponse;
        }

        public async Task<ApiResponse<UpcomingChestsList>> GetUpcomingChestsResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<UpcomingChestsList>(UrlPathBuilder.GetUpcomingChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<PlayerDetail> GetPlayerAsync(string playerTag)
        {
            var apiResponse = await GetPlayerResponseAsync(playerTag);

            return apiResponse.GetModel();
        }

        public async Task<List<BattleLog>> GetBattlesAsync(string playerTag)
        {
            var apiResponse = await GetBattlesResponseAsync(playerTag);

            return apiResponse.GetModel();
        }

        public async Task<UpcomingChestsList> GetUpcomingChests(string playerTag)
        {
            var apiResponse = await GetUpcomingChestsResponseAsync(playerTag);

            return apiResponse.GetModel();
        }
    }
}
