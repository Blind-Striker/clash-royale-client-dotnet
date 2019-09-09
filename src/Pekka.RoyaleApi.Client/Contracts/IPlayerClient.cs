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
        Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag, PlayerFilter playerFilter = null);
        Task<IApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, PlayerFilter playerFilter = null);
        Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);
        Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);
        Task<IApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag, PlayerChestFilter playerChestFilter = null);
        Task<IApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, PlayerChestFilter playerChestFilter = null);
        Task<IApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null);
        Task<IApiResponse<List<Player>>> GetPopularPlayersResponseAsync(PlayerFilter playerFilter = null);
    }

    public interface IPlayerClientWithModel
    {
        Task<Player> GetPlayerAsync(string playerTag, PlayerFilter playerFilter = null);
        Task<List<Player>> GetPlayersAsync(string[] playerTags, PlayerFilter playerFilter = null);
        Task<List<Battle>> GetBattlesAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);
        Task<List<Battle>> GetBattlesAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);
        Task<PlayerChest> GetChestAsync(string playerTag, PlayerChestFilter playerChestFilter = null);
        Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, PlayerChestFilter playerChestFilter);
        Task<List<PlayerSummary>> GetTopPlayersAsync(Locations location = Locations.None, PlayerSummaryFilter playerSummaryFilter = null);
        Task<List<Player>> GetPopularPlayersAsync(PlayerFilter playerFilter = null);
    }
}