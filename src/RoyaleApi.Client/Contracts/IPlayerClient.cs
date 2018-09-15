using System.Collections.Generic;
using System.Threading.Tasks;
using RoyaleApi.Client.Models;

namespace RoyaleApi.Client.Contracts
{
    public interface IPlayerClient
    {
        Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag);
        Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playersTag);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playersTag);
        Task<ApiResponse<Chest>> GetChestResponseAsync(string playerTag);
        Task<ApiResponse<List<Chest>>> GetChestsResponseAsync(params string[] playersTag);

        Task<Player> GetPlayerAsync(string playerTag);
        Task<List<Player>> GetPlayersAsync(params string[] playersTag);
        Task<List<Battle>> GetBattlesAsync(string playerTag);
        Task<List<Battle>> GetBattlesAsync(params string[] playersTag);
        Task<Chest> GetChestAsync(string playerTag);
        Task<List<Chest>> GetChestsAsync(params string[] playersTag);
    }
}