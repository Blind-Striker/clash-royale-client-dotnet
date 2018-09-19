using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IClanClient
    {
        Task<ApiResponse<ClanSearchResult>> SearchClanResponseAsync(ClanFilter clanFilter);
        Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag);
        Task<ApiResponse<ClanMemberList>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);
        Task<ApiResponse<WarLog>> GetWarlogResponseAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null);
        Task<ApiResponse<CurrentWar>> GetCurrentWarResponseAsync(string clanTag);
        Task<ClanSearchResult> SearchClanAsync(ClanFilter clanFilter);
        Task<Clan> GetClanAsync(string clanTag);
        Task<ClanMemberList> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);
        Task<WarLog> GetWarlogAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null);
        Task<CurrentWar> GetCurrentWar(string clanTag);
    }
}