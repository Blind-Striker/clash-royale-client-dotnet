using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Contracts;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class VersionClient : IVersionClient
    {
        private readonly IRestApiClient _restApiClient;

        public VersionClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        //public async Task<IApiResponse> GetVersionResponse()
        //{
        //   return await _restApiClient.GetApiResponseAsync(UrlPathBuilder.Version);
        //}

        public async Task<string> GetVersion()
        {
            string content = await _restApiClient.GetStringContentAsync(UrlPathBuilder.Version);

            return content;
        }
    }
}