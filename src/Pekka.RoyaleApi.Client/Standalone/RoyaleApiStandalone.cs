using System.Net.Http;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;

namespace Pekka.RoyaleApi.Client.Standalone
{
    public class RoyaleApiStandalone : IRoyaleApiClientContext
    {
        private RoyaleApiStandalone(IVersionClient versionClient, IPlayerClient playerClient, IClanClient clanClient)
        {
            VersionClient = versionClient;
            PlayerClient = playerClient;
            ClanClient = clanClient;
        }

        public IVersionClient VersionClient { get; }
        public IPlayerClient PlayerClient { get; }
        public IClanClient ClanClient { get; }

        public static IRoyaleApiClientContext Create(string baseUrl, string authToken, HttpClient httpClient = null)
        {   
            return Create(new ApiOptions(authToken, baseUrl), httpClient);
        }

        public static IRoyaleApiClientContext Create(ApiOptions apiOptions, HttpClient httpClient = null)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }

            IRestApiClient restApiClient = new Core.RestApiClient(httpClient, apiOptions);
            IRoyaleApiClientContext apiClientContext = new RoyaleApiStandalone(new VersionClient(restApiClient), new PlayerClient(restApiClient), new ClanClient(restApiClient));

            return apiClientContext;
        }
    }
}
