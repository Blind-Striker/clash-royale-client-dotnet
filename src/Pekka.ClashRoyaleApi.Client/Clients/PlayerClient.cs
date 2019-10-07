using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class PlayerClient : BaseClient, IPlayerClient
    {
        public PlayerClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            IApiResponse<Player> apiResponse = await RestApiClient.GetApiResponseAsync<Player>(UrlPathBuilder.GetPlayerUrl(playerTag));

            return apiResponse;
        }

        public async Task<IApiResponse<List<PlayerBattleLog>>> GetBattlesResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            IApiResponse<List<PlayerBattleLog>> apiResponse = await RestApiClient.GetApiResponseAsync<List<PlayerBattleLog>>(UrlPathBuilder.GetBattlelogUrl(playerTag));

            return apiResponse;
        }

        public async Task<IApiResponse<PlayerUpcomingChests>> GetUpcomingChestsResponseAsync(string playerTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(playerTag, nameof(playerTag));

            IApiResponse<PlayerUpcomingChests> apiResponse = await RestApiClient.GetApiResponseAsync<PlayerUpcomingChests>(UrlPathBuilder.GetUpcomingChestsUrl(playerTag));

            return apiResponse;
        }

        public async Task<Player> GetPlayerAsync(string playerTag)
        {
            IApiResponse<Player> apiResponse = await GetPlayerResponseAsync(playerTag);

            return apiResponse.Model;
        }

        public async Task<List<PlayerBattleLog>> GetBattlesAsync(string playerTag)
        {
            IApiResponse<List<PlayerBattleLog>> apiResponse = await GetBattlesResponseAsync(playerTag);

            return apiResponse.Model;
        }

        public async Task<PlayerUpcomingChests> GetUpcomingChests(string playerTag)
        {
            IApiResponse<PlayerUpcomingChests> apiResponse = await GetUpcomingChestsResponseAsync(playerTag);

            return apiResponse.Model;
        }
    }
}