﻿using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models.PlayerModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IPlayerClient : IPlayerClientWithApiResponse, IPlayerClientWithModel
    {
    }

    public interface IPlayerClientWithApiResponse
    {
        Task<IApiResponse<Player>> GetPlayerResponseAsync(string playerTag, PlayerFilter playerFilter = null);

        //Task<IApiResponse<List<Player>>> GetPlayersResponseAsync(string[] playerTags, PlayerFilter playerFilter = null);

        Task<IApiResponse<List<PlayerBattle>>> GetBattlesResponseAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);

        //Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);

        Task<IApiResponse<PlayerChest>> GetChestResponseAsync(string playerTag, PlayerChestFilter playerChestFilter = null);

        //Task<IApiResponse<List<PlayerChest>>> GetChestsResponseAsync(string[] playerTags, PlayerChestFilter playerChestFilter = null);

        //Task<IApiResponse<List<PlayerSummary>>> GetTopPlayersResponseAsync(LocationsEnum locationEnum = LocationsEnum.None,
        //    PlayerSummaryFilter playerSummaryFilter = null);

        //Task<IApiResponse<List<Player>>> GetPopularPlayersResponseAsync(PlayerFilter playerFilter = null);
    }

    public interface IPlayerClientWithModel
    {
        Task<Player> GetPlayerAsync(string playerTag, PlayerFilter playerFilter = null);

        //Task<List<Player>> GetPlayersAsync(string[] playerTags, PlayerFilter playerFilter = null);

        Task<List<PlayerBattle>> GetBattlesAsync(string playerTag, PlayerBattleFilter playerBattleFilter = null);

        //Task<List<Battle>> GetBattlesAsync(string[] playerTags, PlayerBattleFilter playerBattleFilter = null);

        Task<PlayerChest> GetChestAsync(string playerTag, PlayerChestFilter playerChestFilter = null);

        //Task<List<PlayerChest>> GetChestsAsync(string[] playerTags, PlayerChestFilter playerChestFilter);

        //Task<List<PlayerSummary>> GetTopPlayersAsync(LocationsEnum locationEnum = LocationsEnum.None,
        //    PlayerSummaryFilter playerSummaryFilter = null);

        //Task<List<Player>> GetPopularPlayersAsync(PlayerFilter playerFilter = null);
    }
}