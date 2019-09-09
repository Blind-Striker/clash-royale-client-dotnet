using Pekka.Core;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models;
using Pekka.RoyaleApi.Client.Models.ClanModels;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IClanClient : IClanClientWithApiResponse, IClanClientWithModel
    {
    }

    public interface IClanClientWithApiResponse
    {
        Task<IApiResponse<List<ClanSummary>>> SearchClanResponseAsync(ClanSummaryFilter clanSummaryFilter = null);

        Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag, ClanFilter clanFilter = null);

        Task<IApiResponse<List<Clan>>> GetClansResponseAsync(string[] clanTags, ClanFilter clanFilter = null);

        Task<IApiResponse<List<Battle>>> GetBattlesResponseAsync(string clanTag,
            ClanBattleFilter clanBattleFilter = null);

        Task<IApiResponse<List<ClanWarLog>>> GetWarLogsResponseAsync(string clanTag,
            ClanWarLogFilter clanWarLogFilter = null);

        Task<IApiResponse<ClanWar>> GetWarResponseAsync(string clanTag, ClanWarFilter clanWarFilter = null);

        Task<IApiResponse<ClanTracking>> GetTrackingResponseAsync(string clanTag,
            ClanTrackingFilter clanTrackingFilter = null);

        Task<IApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryDailyResponseAsync(string clanTag,
            ClanHistoryFilter clanHistoryFilter = null);

        Task<IApiResponse<Dictionary<string, ClanHistory>>> GetClanHistoryWeeklyResponseAsync(string clanTag,
            ClanHistoryFilter clanHistoryFilter = null);

        Task<IApiResponse<List<ClanSummary>>> GetTopClansResponseAsync(Locations location = Locations.None,
            ClanSummaryFilter clanSummaryFilter = null);

        Task<IApiResponse<List<Clan>>> GetPopularPlayersResponseAsync(ClanFilter clanFilter = null);

        Task<IApiResponse<List<ClanSummary>>> GetTopWarClanWarsResponseAsync(Locations location = Locations.None,
            ClanSummaryFilter clanSummaryFilter = null);
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

        Task<Dictionary<string, ClanHistory>> GetClanHistoryDailyAsync(string clanTag,
            ClanHistoryFilter clanHistoryFilter = null);

        Task<Dictionary<string, ClanHistory>> GetClanHistoryWeeklyAsync(string clanTag,
            ClanHistoryFilter clanHistoryFilter = null);

        Task<List<ClanSummary>> GetTopClanAsync(Locations location = Locations.None,
            ClanSummaryFilter clanSummaryFilter = null);

        Task<List<ClanSummary>> GetTopWarClanWarsAsync(Locations location = Locations.None,
            ClanSummaryFilter clanSummaryFilter = null);

        Task<List<Clan>> GetPopularClanAsync(ClanFilter clanFilter = null);
    }
}