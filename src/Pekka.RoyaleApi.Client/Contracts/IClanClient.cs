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
        Task<ApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanSummaryFilter clanSummaryFilter = null);
        Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag, ClanFilter clanFilter = null);
        Task<ApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, ClanFilter clanFilter = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);
        Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, ClanWarFilter clanWarFilter = null);
        Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null);
        Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryDailyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<ApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryWeeklyResponseAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<ApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null);
        Task<ApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(ClanFilter clanFilter = null);
        Task<ApiResponse<List<ClanSummary>>> GetTopWarClanWarsResponseAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null);
    }

    public interface IClanClientWithModel
    {
        Task<List<ClanSummary>> SearchClanAsync(ClanSummaryFilter clanSummaryFilter = null);
        Task<Clan> GetClanAsync(string clanTag, ClanFilter clanFilter = null);
        Task<List<Clan>> GetClansAsync(string[] clanTags, ClanFilter clanFilter = null);
        Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);
        Task<ClanWar> GetWarAsync(string clanTag, ClanWarFilter clanWarFilter = null);
        Task<ClanTracking> GetTrackingAsync(string clanTag, ClanTrackingFilter clanTrackingFilter = null);
        Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklyAsync(string clanTag, ClanHistoryFilter clanHistoryFilter = null);
        Task<List<ClanSummary>> GetTopClanAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null);
        Task<List<ClanSummary>> GetTopWarClanWarsAsync(Locations location = Locations.None, ClanSummaryFilter clanSummaryFilter = null);
        Task<List<Clan>> GetPopularClanAsync(ClanFilter clanFilter = null);
    }
}