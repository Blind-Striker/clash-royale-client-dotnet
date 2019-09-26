using System.Collections.Generic;
using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class GlobalTournamentClient : BaseClient, IGlobalTournamentClient
    {
        public GlobalTournamentClient(IRestApiClient restApiClient) 
            : base(restApiClient)
        {
        }

        public async Task<IApiResponse<List<Card>>> GetGlobalTournamentsResponseAsync()
        {
            var apiResponse = await RestApiClient.GetApiResponseAsync<List<Card>>(UrlPathBuilder.CardUrl);

            return apiResponse;
        }

        public async Task<List<Card>> GetGlobalTournamentsAsync()
        {
            var apiResponse = await GetGlobalTournamentsResponseAsync();

            return apiResponse.Model;
        }
    }
}
