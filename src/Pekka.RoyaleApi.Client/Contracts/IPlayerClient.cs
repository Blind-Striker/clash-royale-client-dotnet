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
        Task<ApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, PlayerFilter playerFilter = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);
        Task<ApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag);
        Task<ApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, PlayerChestFilter playerChestFilter = null);
        Task<ApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null);
        Task<ApiResponse<List<Player>>> GetPopularPlayersResponseAsync(PlayerFilter playerFilter = null);
    }

    public interface IPlayerClientWithModel
    {
        Task<Player> GetPlayerAsync(string playerTag);
        Task<List<Player>> GetPlayersAsync(string[] playerTags, PlayerFilter playerFilter = null);
        Task<List<Battle>> GetBattlesAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);
        Task<List<Battle>> GetBattlesAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);
        Task<PlayerChest> GetChestAsync(string playerTag);
        Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, PlayerChestFilter playerChestFilter);
        Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null);
        Task<List<Player>> GetPopularPlayersAsync(PlayerFilter playerFilter = null);
    }
}