using System.Net.Http;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;

namespace Pekka.RoyaleApi.Client.Standalone
{
    public interface IRoyaleApiClientContext
    {
        IVersionClient VersionClient { get; }
        IPlayerClient PlayerClient { get; }
        IClanClient ClanClient { get; }
    }

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

        public static IRoyaleApiClientContext Create(string baseUrl, string authToken)
        {   
            return Create(new ApiOptions(authToken, baseUrl));
        }

        public static IRoyaleApiClientContext Create(ApiOptions apiOptions)
        {
            HttpClient httpClient = new HttpClient();

            Core.Contracts.IRestApiClient restApiClient = new Core.RestApiClient(httpClient, apiOptions);
            IRoyaleApiClientContext apiClientContext = new RoyaleApiStandalone(new VersionClient(restApiClient), new PlayerClient(restApiClient), new ClanClient(restApiClient));

            return apiClientContext;
        }
    }
}
