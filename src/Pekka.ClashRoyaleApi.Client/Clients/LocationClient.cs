using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Responses;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Pekka.Core;

using LocationEnum = Pekka.Core.Locations;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class LocationClient : BaseClient, ILocationClient
    {
        public LocationClient(IRestApiClient restApiClient) : base(restApiClient)
        {
        }

        public async Task<IApiResponse<List<Location>>> GetLocationsResponseAsync(LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");

            var apiResponse =
                await RestApiClient.GetApiResponseAsync<List<Location>>(UrlPathBuilder.LocationUrl, locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<Location>> GetLocationResponseAsync(LocationEnum location)
        {
            var apiResponse = await RestApiClient.GetApiResponseAsync<Location>(UrlPathBuilder.GetLocationUrl((int) location));

            return apiResponse;
        }

        public async Task<IApiResponse<LocationRankingClans>> GetClanRankingsResponseAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");

            var apiResponse = await RestApiClient.GetApiResponseAsync<LocationRankingClans>(UrlPathBuilder.GetRankingsClanUrl((int) location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<LocationRankingPlayers>> GetPlayerRankingsResponseAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");

            var apiResponse = await RestApiClient.GetApiResponseAsync<LocationRankingPlayers>(UrlPathBuilder.GetRankingsPlayerUrl((int) location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<IApiResponse<LocationRankingClanWars>> GetClanWarsRankingsResponseAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");

            var apiResponse = await RestApiClient.GetApiResponseAsync<LocationRankingClanWars>(UrlPathBuilder.GetRankingsClanWarUrl((int) location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<List<Location>> GetLocationsAsync(LocationFilter locationFilter = null)
        {
            var apiResponse = await GetLocationsResponseAsync(locationFilter);

            return apiResponse.Model;
        }

        public async Task<Location> GetLocationAsync(LocationEnum location)
        {
            var apiResponse = await GetLocationResponseAsync(location);

            return apiResponse.Model;
        }

        public async Task<LocationRankingClans> GetClanRankingsAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetClanRankingsResponseAsync(location, locationFilter);

            return apiResponse.Model;
        }

        public async Task<LocationRankingPlayers> GetPlayerRankingsAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetPlayerRankingsResponseAsync(location, locationFilter);

            return apiResponse.Model;
        }

        public async Task<LocationRankingClanWars> GetClanWarsRankingsAsync(LocationEnum location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetClanWarsRankingsResponseAsync(location, locationFilter);

            return apiResponse.Model;
        }
    }
}