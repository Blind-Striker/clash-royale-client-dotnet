using System.Threading.Tasks;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;
using Pekka.RoyaleApi.Client.Contracts;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class VersionClient : IVersionClient
    {
        private readonly IRoyaleApiClient _royaleApiClient;

        public VersionClient(IRoyaleApiClient royaleApiClient)
        {
            _royaleApiClient = royaleApiClient;
        }

        public async Task<ApiResponse> GetVersionResponse()
        {
           return await _royaleApiClient.GetStringContentAsync(UrlBuilder.Version);
        }

        public async Task<string> GetVersion()
        {
            ApiResponse apiResponse = await _royaleApiClient.GetStringContentAsync(UrlBuilder.Version);

            return apiResponse.Message;
        }
    }
}
