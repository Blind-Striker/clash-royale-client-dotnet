using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class GlobalTournamentClient : BaseClient, IGlobalTournamentClient
    {
        public GlobalTournamentClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<List<Card>>> GetGlobalTournamentsResponseAsync()
        {
            IApiResponse<List<Card>> apiResponse = await RestApiClient.GetApiResponseAsync<List<Card>>(UrlPathBuilder.CardUrl);

            return apiResponse;
        }

        public async Task<List<Card>> GetGlobalTournamentsAsync()
        {
            IApiResponse<List<Card>> apiResponse = await GetGlobalTournamentsResponseAsync();

            return apiResponse.Model;
        }
    }
}