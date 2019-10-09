using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

using System;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class ClanClient : BaseClient, IClanClient
    {
        public ClanClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<PagedClans>> SearchClanResponseAsync(ClanFilter clanApiFilter)
        {
            Ensure.ArgumentNotNull(clanApiFilter, nameof(clanApiFilter));
            Ensure.AtleastOneCriteriaMustBeDefined(clanApiFilter, nameof(clanApiFilter));

            if (clanApiFilter.Name != null && clanApiFilter.Name.Length < 3)
            {
                throw new ArgumentException("Name needs to be at least three characters long.", nameof(ClanFilter.Name));
            }

            if (clanApiFilter.After.HasValue && clanApiFilter.Before.HasValue)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedClans> apiResponse = await RestApiClient.GetApiResponseAsync<PagedClans>(UrlPathBuilder.ClanUrl, clanApiFilter.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Clan>> GetClanResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<Clan> apiResponse = await RestApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<IApiResponse<PagedClanMembers>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            if (clanMemberFilter?.After != null && clanMemberFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedClanMembers> apiResponse =
                await RestApiClient.GetApiResponseAsync<PagedClanMembers>(UrlPathBuilder.GetMemberUrl(clanTag), clanMemberFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<PagedClanWarLogs>> GetWarLogResponseAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            if (clanWarLogFilter?.After != null && clanWarLogFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedClanWarLogs> apiResponse = await RestApiClient.GetApiResponseAsync<PagedClanWarLogs>(UrlPathBuilder.GetWarlogUrl(clanTag),
                                                                                                         clanWarLogFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<ClanCurrentWar>> GetCurrentWarResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            IApiResponse<ClanCurrentWar> apiResponse = await RestApiClient.GetApiResponseAsync<ClanCurrentWar>(UrlPathBuilder.GetCurrentWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<PagedClans> SearchClanAsync(ClanFilter clanApiFilter)
        {
            IApiResponse<PagedClans> apiResponse = await SearchClanResponseAsync(clanApiFilter);

            return apiResponse.Model;
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            IApiResponse<Clan> apiResponse = await GetClanResponseAsync(clanTag);

            return apiResponse.Model;
        }

        public async Task<PagedClanMembers> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null)
        {
            IApiResponse<PagedClanMembers> apiResponse = await GetMembersResponseAsync(clanTag, clanMemberFilter);

            return apiResponse.Model;
        }

        public async Task<PagedClanWarLogs> GetWarLogAsync(string clanTag, ClanWarLogFilter clanWarLogFilter = null)
        {
            IApiResponse<PagedClanWarLogs> apiResponse = await GetWarLogResponseAsync(clanTag, clanWarLogFilter);

            return apiResponse.Model;
        }

        public async Task<ClanCurrentWar> GetCurrentWar(string clanTag)
        {
            IApiResponse<ClanCurrentWar> apiResponse = await GetCurrentWarResponseAsync(clanTag);

            return apiResponse.Model;
        }
    }
}