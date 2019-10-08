using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Responses;

using System;
using System.Threading.Tasks;


namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class LocationClient : BaseClient, ILocationClient
    {
        public LocationClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<PagedLocations>> GetLocationsResponseAsync(LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedLocations> apiResponse = await RestApiClient.GetApiResponseAsync<PagedLocations>(UrlPathBuilder.LocationUrl, locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Location>> GetLocationResponseAsync(LocationsEnum locationEnum)
        {
            IApiResponse<Location> apiResponse = await RestApiClient.GetApiResponseAsync<Location>(UrlPathBuilder.GetLocationUrl((int) locationEnum));

            return apiResponse;
        }

        public async Task<IApiResponse<PagedLocationRankingClans>> GetClanRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedLocationRankingClans> apiResponse =
                await RestApiClient.GetApiResponseAsync<PagedLocationRankingClans>(UrlPathBuilder.GetRankingsClanUrl((int) locationEnum), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<PagedLocationRankingPlayers>> GetPlayerRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedLocationRankingPlayers> apiResponse = await RestApiClient.GetApiResponseAsync<PagedLocationRankingPlayers>(
                                                                   UrlPathBuilder.GetRankingsPlayerUrl((int) locationEnum), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<PagedLocationRankingClanWars>> GetClanWarsRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            IApiResponse<PagedLocationRankingClanWars> apiResponse = await RestApiClient.GetApiResponseAsync<PagedLocationRankingClanWars>(
                                                                    UrlPathBuilder.GetRankingsClanWarUrl((int) locationEnum), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<PagedLocations> GetLocationsAsync(LocationFilter locationFilter = null)
        {
            IApiResponse<PagedLocations> apiResponse = await GetLocationsResponseAsync(locationFilter);

            return apiResponse.Model;
        }

        public async Task<Location> GetLocationAsync(LocationsEnum locationEnum)
        {
            IApiResponse<Location> apiResponse = await GetLocationResponseAsync(locationEnum);

            return apiResponse.Model;
        }

        public async Task<PagedLocationRankingClans> GetClanRankingsAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            IApiResponse<PagedLocationRankingClans> apiResponse = await GetClanRankingsResponseAsync(locationEnum, locationFilter);

            return apiResponse.Model;
        }

        public async Task<PagedLocationRankingPlayers> GetPlayerRankingsAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            IApiResponse<PagedLocationRankingPlayers> apiResponse = await GetPlayerRankingsResponseAsync(locationEnum, locationFilter);

            return apiResponse.Model;
        }

        public async Task<PagedLocationRankingClanWars> GetClanWarsRankingsAsync(LocationsEnum locationEnum, LocationFilter locationFilter = null)
        {
            IApiResponse<PagedLocationRankingClanWars> apiResponse = await GetClanWarsRankingsResponseAsync(locationEnum, locationFilter);

            return apiResponse.Model;
        }
    }
}