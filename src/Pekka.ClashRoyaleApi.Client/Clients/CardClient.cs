using System.Collections.Generic;

using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class CardClient : BaseClient, ICardClient
    {
        public CardClient(IRestApiClient restApiClient) 
            : base(restApiClient)
        {
        }

        public async Task<IApiResponse<List<Card>>> GetCardsResponseAsync()
        {
            var apiResponse = await RestApiClient.GetApiResponseAsync<List<Card>>(UrlPathBuilder.CardUrl);

            return apiResponse;
        }

        public async Task<List<Card>> GetCardsAsync()
        {
            var apiResponse = await GetCardsResponseAsync();

            return apiResponse.Model;
        }
    }
}