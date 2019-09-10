using System;

using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;

using System.Net.Http;
using System.Net.Http.Headers;

namespace Pekka.RoyaleApi.Client.Standalone
{
    public class RoyaleApiStandalone : IRoyaleApiClientContext
    {
        private RoyaleApiStandalone(
            IVersionClient versionClient,
            IConstantClient constantClient,
            IPlayerClient playerClient,
            IClanClient clanClient,
            ITournamentClient tournamentClient)
        {
            VersionClient = versionClient;
            ConstantClient = constantClient;
            PlayerClient = playerClient;
            ClanClient = clanClient;
            TournamentClient = tournamentClient;
        }

        public IVersionClient VersionClient { get; }

        public IConstantClient ConstantClient { get; }

        public IPlayerClient PlayerClient { get; }

        public IClanClient ClanClient { get; }

        public ITournamentClient TournamentClient { get; }

        public static IRoyaleApiClientContext Create(string baseUrl, string authToken, HttpClient httpClient = null)
        {
            return Create(new ApiOptions(authToken, baseUrl), httpClient);
        }

        public static IRoyaleApiClientContext Create(ApiOptions apiOptions, HttpClient httpClient = null)
        {
            if (httpClient == null) httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(apiOptions.BaseUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiOptions.BearerToken);

            IRestApiClient restApiClient = new RestApiClient(httpClient);

            IRoyaleApiClientContext apiClientContext = new RoyaleApiStandalone(
                new VersionClient(restApiClient),
                new ConstantClient(restApiClient),
                new PlayerClient(restApiClient),
                new ClanClient(restApiClient),
                new TournamentClient(restApiClient));

            return apiClientContext;
        }
    }
}