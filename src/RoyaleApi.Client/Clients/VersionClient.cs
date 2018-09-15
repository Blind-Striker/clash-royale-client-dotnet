using System.Threading.Tasks;
using RoyaleApi.Client.Contracts;

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
           return await _royaleApiClient.GetStringContentAsync("version");
        }

        public async Task<string> GetVersion()
        {
            ApiResponse apiResponse = await _royaleApiClient.GetStringContentAsync("version");

            return apiResponse.Content;
        }
    }
}
