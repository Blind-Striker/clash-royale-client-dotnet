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
        Task<IApiResponse<Clan>> SearchClanResponseAsync(ClanFilter clanApiFilter);

        Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag);

        Task<IApiResponse<ClanMembers>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<IApiResponse<ClanWarLogs>> GetWarLogResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);

        Task<IApiResponse<ClanCurrentWar>> GetCurrentWarResponseAsync(string clanTag);
    }

    public interface IClanClientWithModel
    {
        Task<Clan> SearchClanAsync(ClanFilter clanApiFilter);

        Task<Clan> GetClanAsync(string clanTag);

        Task<ClanMembers> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null);

        Task<ClanWarLogs> GetWarLogAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null);

        Task<ClanCurrentWar> GetCurrentWar(string clanTag);
    }
}