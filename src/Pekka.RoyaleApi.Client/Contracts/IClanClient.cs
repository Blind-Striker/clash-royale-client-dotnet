using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IClanClient : IClanClientWithApiResponse, IClanClientWithModel
    {
    }

    public interface IClanClientWithApiResponse
    {
        Task<ApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanFilter clanFilter = null);
        Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag);
        Task<ApiResponse<List<Clan>>> GetClansResponseAsync(params string[] clanTags);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, Pagination pagination = null);
        Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag);
        Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag);
        Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryDailyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryWeeklyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<ApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(Locations location = Locations.None, Pagination pagination = null);
        Task<ApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(Pagination pagination = null);
        Task<ApiResponse<List<ClanSummary>>> GetGetTopWarClanWarsResponseAsync(Locations location = Locations.None, Pagination pagination = null);
    }

    public interface IClanClientWithModel
    {
        Task<List<ClanSummary>> SearchClanAsync(ClanFilter clanFilter = null);
        Task<Clan> GetClanAsync(string clanTag);
        Task<List<Clan>> GetClansAsync(params string[] clanTags);
        Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, Pagination pagination = null);
        Task<ClanWar> GetWarAsync(string clanTag);
        Task<ClanTracking> GetTrackingAsync(string clanTag);
        Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<List<ClanSummary>> GetTopClanAsync(Locations location = Locations.None, Pagination pagination = null);
        Task<List<Clan>> GetPopularClanAsync(Pagination pagination = null);
        Task<List<ClanSummary>> GetGetTopWarClanWarsAsync(Locations location = Locations.None, Pagination pagination = null);
    }
}