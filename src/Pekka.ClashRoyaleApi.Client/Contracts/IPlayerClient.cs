using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IPlayerClient
    {
        Task<IApiResponse<PlayerDetail>> GetPlayerResponseAsync(string playerTag);

        Task<IApiResponse<List<BattleLog>>> GetBattlesResponseAsync(string playerTag);

        Task<IApiResponse<UpcomingChestsList>> GetUpcomingChestsResponseAsync(string playerTag);

        Task<PlayerDetail> GetPlayerAsync(string playerTag);

        Task<List<BattleLog>> GetBattlesAsync(string playerTag);

        Task<UpcomingChestsList> GetUpcomingChests(string playerTag);
    }
}