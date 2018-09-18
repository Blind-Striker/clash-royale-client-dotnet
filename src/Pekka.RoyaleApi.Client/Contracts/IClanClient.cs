using System.Collections.Generic;
using System.Threading.Tasks;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.ClanModels;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IClanClient : IClanClientWithApiResponse, IClanClientWithModel
    {
    }

    public interface IClanClientWithApiResponse
    {
        Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag);
        Task<ApiResponse<List<Clan>>> GetClansResponseAsync(params string[] clanTags);
        Task<ApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag, ClanBattleType clanBattleType = null);
        Task<ApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag);
        Task<ApiResponse<ClanWar>> GetWarResponseAsync(string clanTag);
        Task<ApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag);
    }

    public interface IClanClientWithModel
    {
        Task<Clan> GetClanAsync(string clanTag);
        Task<List<Clan>> GetClansAsync(params string[] clanTags);
        Task<List<Battle>> GetBattlesAsync(string clanTag, ClanBattleType clanBattleType = null);
        Task<List<ClanWarLog>> GetWarLogsAsync(string clanTag);
        Task<ClanWar> GetWarAsync(string clanTag);
        Task<ClanTracking> GetTrackingAsync(string clanTag);
    }
}