using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core;
using Pekka.Core.Contracts;

using System.Net.Http;

namespace Pekka.ClashRoyaleApi.Client.Standalone
{
    public class ClashRoyaleApiStandalone : IClashRoyaleApiClientContext
    {
        private ClashRoyaleApiStandalone(IPlayerClient playerClient, IClanClient clanClient,
            ILocationClient locationClient, ITournamentClient tournamentClient, ICardClient cardClient)
        {
            PlayerClient = playerClient;
            ClanClient = clanClient;
            LocationClient = locationClient;
            TournamentClient = tournamentClient;
            CardClient = cardClient;
        }

        public IPlayerClient PlayerClient { get; }

        public IClanClient ClanClient { get; }

        public ILocationClient LocationClient { get; }

        public ITournamentClient TournamentClient { get; }

        public ICardClient CardClient { get; }

        public static IClashRoyaleApiClientContext Create(string baseUrl, string authToken,
            HttpClient httpClient = null)
        {
            return Create(new ApiOptions(authToken, baseUrl), httpClient);
        }

        public static IClashRoyaleApiClientContext Create(ApiOptions apiOptions, HttpClient httpClient = null)
        {
            if (httpClient == null) httpClient = new HttpClient();

            IRestApiClient restApiClient = new RestApiClient(httpClient, apiOptions);

            IClashRoyaleApiClientContext apiClientContext = new ClashRoyaleApiStandalone(
                new PlayerClient(restApiClient),
                new ClanClient(restApiClient),
                new LocationClient(restApiClient),
                new TournamentClient(restApiClient),
                new CardClient(restApiClient));

            return apiClientContext;
        }
    }
}