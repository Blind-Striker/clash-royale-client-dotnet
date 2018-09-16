using System.Threading.Tasks;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Responses;

namespace RoyaleApi.Client.Clients
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
           return await _royaleApiClient.GetStringContentAsync(Endpoints.Version);
        }

        public async Task<string> GetVersion()
        {
            ApiResponse apiResponse = await _royaleApiClient.GetStringContentAsync(Endpoints.Version);

            return apiResponse.Message;
        }
    }
}
