using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.Core.Responses;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IClanClient
    {
        Task<IApiResponse<ClanSearchResult>> SearchClanResponseAsync(ClanFilter clanApiFilter);

        Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag);

        Task<IApiResponse<ClanMemberList>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<IApiResponse<WarLog>> GetWarlogResponseAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null);

        Task<IApiResponse<CurrentWar>> GetCurrentWarResponseAsync(string clanTag);

        Task<ClanSearchResult> SearchClanAsync(ClanFilter clanApiFilter);

        Task<Clan> GetClanAsync(string clanTag);

        Task<ClanMemberList> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<WarLog> GetWarlogAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null);

        Task<CurrentWar> GetCurrentWar(string clanTag);
    }
}