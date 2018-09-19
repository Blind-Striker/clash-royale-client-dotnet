using System.Collections.Generic;
using System.Threading.Tasks;
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
        Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag, Pagination pagination = null);
        Task<ApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, Pagination pagination = null);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag, Pagination pagination = null);
        Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, Pagination pagination = null);
        Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag, Pagination pagination = null);
    }

    public interface IClanClientWithModel
    {
        Task<List<ClanSummary>> SearchClanAsync(ClanFilter clanFilter = null);
        Task<Clan> GetClanAsync(string clanTag, Pagination pagination = null);
        Task<List<Clan>> GetClansAsync(string[] clanTags, Pagination pagination = null);
        Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleFilter clanBattleFilter = null);
        Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag, Pagination pagination = null);
        Task<ClanWar> GetWarAsync(string clanTag, Pagination pagination = null);
        Task<ClanTracking> GetTrackingAsync(string clanTag, Pagination pagination = null);
    }
}