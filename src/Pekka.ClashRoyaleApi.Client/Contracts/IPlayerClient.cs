using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IPlayerClient
    {
        Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag);

        Task<IApiResponse<List<PlayerBattleLog>>> GetBattlesResponseAsync(string playerTag);

        Task<IApiResponse<PlayerUpcomingChests>> GetUpcomingChestsResponseAsync(string playerTag);

        Task<Player> GetPlayerAsync(string playerTag);

        Task<List<PlayerBattleLog>> GetBattlesAsync(string playerTag);

        Task<PlayerUpcomingChests> GetUpcomingChests(string playerTag);
    }
}