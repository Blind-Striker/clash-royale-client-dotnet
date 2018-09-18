using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IPlayerClient
    {
        Task<ApiResponse<PlayerDetail>> GetPlayerResponseAsync(string playerTag);
        Task<ApiResponse<List<BattleLog>>> GetBattlesResponseAsync(string playerTag);
        Task<ApiResponse<UpcomingChestsList>> GetUpcomingChestsResponseAsync(string playerTag);
        Task<PlayerDetail> GetPlayerAsync(string playerTag);
        Task<List<BattleLog>> GetBattlesAsync(string playerTag);
        Task<UpcomingChestsList> GetUpcomingChests(string playerTag);
    }
}