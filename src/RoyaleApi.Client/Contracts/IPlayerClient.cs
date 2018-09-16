using System.Collections.Generic;
using System.Threading.Tasks;
using RoyaleApi.Client.Models;
using RoyaleApi.Client.Models.Player;
using RoyaleApi.Client.Responses;

namespace RoyaleApi.Client.Contracts
{
    public interface IPlayerClient : IPlayerClientWithApiResponse, IPlayerClientWithModel
    {
    }

    public interface IPlayerClientWithApiResponse
    {
        Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag);
        Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(params string[] playerTags);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(params string[] playerTags);
        Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag);
        Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(params string[] playerTags);
        Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, int max = 10, int page = 0);
        Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync();
    }

    public interface IPlayerClientWithModel
    {
        Task<Player> GetPlayerAsync(string playerTag);
        Task<List<Player>> GetPlayersAsync(params string[] playerTags);
        Task<List<Battle>> GetBattlesAsync(string playerTag);
        Task<List<Battle>> GetBattlesAsync(params string[] playerTags);
        Task<PlayerChest> GetChestAsync(string playerTag);
        Task<List<PlayerChest>> GetChestsAsync(params string[] playerTags);
        Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, int max = 10, int page = 0);
        Task<List<Player>> GetPopularPlayersAsync();
    }
}