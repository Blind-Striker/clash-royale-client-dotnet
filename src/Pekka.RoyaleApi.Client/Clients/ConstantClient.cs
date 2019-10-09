using Pekka.Core.Contracts;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Models.ConstantModels;

using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class ConstantClient : IConstantClient
    {
        private readonly IRestApiClient _restApiClient;

        public ConstantClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public Task<IApiResponse<Constants>> GetConstantsResponseAsync()
        {
            return _restApiClient.GetApiResponseAsync<Constants>(UrlPathBuilder.ConstantsUrl);
        }

        public async Task<Constants> GetConstantsAsync()
        {
            IApiResponse<Constants> constantsResponseAsync = await GetConstantsResponseAsync();

            return constantsResponseAsync.Model;
        }
    }
}