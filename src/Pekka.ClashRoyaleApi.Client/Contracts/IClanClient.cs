using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.Core.Responses;

using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface IClanClient : IClanClientWithApiResponse, IClanClientWithModel
    {
    }

    public interface IClanClientWithApiResponse
    {
        Task<IApiResponse<PagedClans>> SearchClanResponseAsync(ClanFilter clanApiFilter);

        Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag);

        Task<IApiResponse<PagedClanMembers>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<IApiResponse<PagedClanWarLogs>> GetWarLogResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);

        Task<IApiResponse<ClanCurrentWar>> GetCurrentWarResponseAsync(string clanTag);
    }

    public interface IClanClientWithModel
    {
        Task<PagedClans> SearchClanAsync(ClanFilter clanApiFilter);

        Task<Clan> GetClanAsync(string clanTag);

        Task<PagedClanMembers> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<PagedClanWarLogs> GetWarLogAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);

        Task<ClanCurrentWar> GetCurrentWar(string clanTag);
    }
}