using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class CardClient : BaseClient, ICardClient
    {
        public CardClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<PagedCards>> GetCardsResponseAsync()
        {
            IApiResponse<PagedCards> apiResponse = await RestApiClient.GetApiResponseAsync<PagedCards>(UrlPathBuilder.CardUrl);

            return apiResponse;
        }

        public async Task<PagedCards> GetCardsAsync()
        {
            IApiResponse<PagedCards> apiResponse = await GetCardsResponseAsync();

            return apiResponse.Model;
        }
    }
}