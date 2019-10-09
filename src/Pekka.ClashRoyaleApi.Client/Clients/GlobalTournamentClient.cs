using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class GlobalTournamentClient : BaseClient, IGlobalTournamentClient
    {
        public GlobalTournamentClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<PagedGlobalTournaments>> GetGlobalTournamentsResponseAsync()
        {
            IApiResponse<PagedGlobalTournaments> apiResponse = await RestApiClient.GetApiResponseAsync<PagedGlobalTournaments>(UrlPathBuilder.GlobalTournaments);

            return apiResponse;
        }

        public async Task<PagedGlobalTournaments> GetGlobalTournamentsAsync()
        {
            IApiResponse<PagedGlobalTournaments> apiResponse = await GetGlobalTournamentsResponseAsync();

            return apiResponse.Model;
        }
    }
}