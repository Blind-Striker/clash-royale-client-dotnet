using System;

using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core;
using Pekka.Core.Contracts;

using System.Net.Http;
using System.Net.Http.Headers;

namespace Pekka.ClashRoyaleApi.Client.Standalone
{
    public class ClashRoyaleApiStandalone : IClashRoyaleApiClientContext
    {
        private ClashRoyaleApiStandalone(
            IPlayerClient playerClient,
            IClanClient clanClient,
            ILocationClient locationClient,
            ITournamentClient tournamentClient,
            ICardClient cardClient,
            IGlobalTournamentClient globalTournamentClient)
        {
            PlayerClient = playerClient;
            ClanClient = clanClient;
            LocationClient = locationClient;
            TournamentClient = tournamentClient;
            CardClient = cardClient;
            GlobalTournamentClient = globalTournamentClient;
        }

        public IPlayerClient PlayerClient { get; }

        public IClanClient ClanClient { get; }

        public ILocationClient LocationClient { get; }

        public ITournamentClient TournamentClient { get; }

        public ICardClient CardClient { get; }

        public IGlobalTournamentClient GlobalTournamentClient { get; }

        public static IClashRoyaleApiClientContext Create(string baseUrl, string authToken, HttpClient httpClient = null)
        {
            return Create(new ApiOptions(authToken, baseUrl), httpClient);
        }

        public static IClashRoyaleApiClientContext Create(ApiOptions apiOptions, HttpClient httpClient = null)
        {
            if (httpClient == null) httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(apiOptions.BaseUrl);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiOptions.BearerToken);

            IRestApiClient restApiClient = new RestApiClient(httpClient);

            IClashRoyaleApiClientContext apiClientContext = new ClashRoyaleApiStandalone(
                new PlayerClient(restApiClient),
                new ClanClient(restApiClient),
                new LocationClient(restApiClient),
                new TournamentClient(restApiClient),
                new CardClient(restApiClient),
                new GlobalTournamentClient(restApiClient));

            return apiClientContext;
        }
    }
}