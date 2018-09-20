using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.PlayerModels;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IPlayerClient : IPlayerClientWithApiResponse, IPlayerClientWithModel
    {
    }

    public interface IPlayerClientWithApiResponse
    {
        Task<ApiResponse<Player>> GetPlayerResponseAsync(string playerTag);
        Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, Pagination pagination = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag, Pagination pagination = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, Pagination pagination = null);
        Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag);
        Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, Pagination pagination = null);
        Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, Pagination pagination = null);
        Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync(Pagination pagination = null);
    }

    public interface IPlayerClientWithModel
    {
        Task<Player> GetPlayerAsync(string playerTag);
        Task<List<Player>> GetPlayersAsync(string[] playerTags, Pagination pagination = null);
        Task<List<Battle>> GetBattlesAsync(string playerTag, Pagination pagination = null);
        Task<List<Battle>> GetBattlesAsync(string[] playerTags, Pagination pagination = null);
        Task<PlayerChest> GetChestAsync(string playerTag);
        Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, Pagination pagination);
        Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, Pagination pagination = null);
        Task<List<Player>> GetPopularPlayersAsync(Pagination pagination = null);
    }
}