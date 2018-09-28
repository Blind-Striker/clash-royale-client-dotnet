using System;
using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class ClanClient : IClanClient
    {
        private readonly IRestApiClient _restApiClient;

        public ClanClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<ApiResponse<ClanSearchResult>> SearchClanResponseAsync(ClanFilter clanApiFilter)
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

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanSearchResult>(UrlPathBuilder.ClanUrl, clanApiFilter.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Clan>> GetClanResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<Clan>(UrlPathBuilder.GetClanUrl(clanTag));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanMemberList>> GetMembersResponseAsync(string clanTag, ClanMemberFilter clanMemberFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            if (clanMemberFilter?.After != null && clanMemberFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanMemberList>(UrlPathBuilder.GetMemberUrl(clanTag), clanMemberFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<WarLog>> GetWarlogResponseAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            if (clanWarlogFilter?.After != null && clanWarlogFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<WarLog>(UrlPathBuilder.GetWarlogUrl(clanTag), clanWarlogFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<CurrentWar>> GetCurrentWarResponseAsync(string clanTag)
        {
            Ensure.ArgumentNotNullOrEmptyString(clanTag, nameof(clanTag));

            var apiResponse = await _restApiClient.GetApiResponseAsync<CurrentWar>(UrlPathBuilder.GetCurrentWarUrl(clanTag));

            return apiResponse;
        }

        public async Task<ClanSearchResult> SearchClanAsync(ClanFilter clanApiFilter)
        {
            var apiResponse = await SearchClanResponseAsync(clanApiFilter);

            return apiResponse.GetModel();
        }

        public async Task<Clan> GetClanAsync(string clanTag)
        {
            var apiResponse = await GetClanResponseAsync(clanTag);

            return apiResponse.GetModel();
        }

        public async Task<ClanMemberList> GetMembersAsync(string clanTag, ClanMemberFilter clanMemberFilter = null)
        {
            var apiResponse = await GetMembersResponseAsync(clanTag, clanMemberFilter);

            return apiResponse.GetModel();
        }

        public async Task<WarLog> GetWarlogAsync(string clanTag, ClanWarlogFilter clanWarlogFilter = null)
        {
            var apiResponse = await GetWarlogResponseAsync(clanTag, clanWarlogFilter);

            return apiResponse.GetModel();
        }

        public async Task<CurrentWar> GetCurrentWar(string clanTag)
        {
            var apiResponse = await GetCurrentWarResponseAsync(clanTag);

            return apiResponse.GetModel();
        }
    }
}
