using Pekka.Core.Contracts;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Models;

using System.Threading.Tasks;

using Pekka.RoyaleApi.Client.Models.VersionModels;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class VersionClient : IVersionClient
    {
        private readonly IRestApiClient _restApiClient;

        public VersionClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public Task<IApiResponse<Ver>> GetVersionResponseAsync()
        {
            return _restApiClient.GetApiResponseAsync<Ver>(UrlPathBuilder.VersionUrl);
        }

        public Task<string> GetVersionAsync()
        {
            return _restApiClient.GetStringContentAsync(UrlPathBuilder.VersionUrl);
        }
    }
}