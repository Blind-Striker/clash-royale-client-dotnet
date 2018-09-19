using System;
using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Clients
{
    public class LocationClient : ILocationClient
    {
        private readonly IRestApiClient _restApiClient;

        public LocationClient(IRestApiClient restApiClient)
        {
            _restApiClient = restApiClient;
        }

        public async Task<ApiResponse<LocationList>> GetLocationsResponseAsync(LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<LocationList>(UrlPathBuilder.LocationUrl, locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<Location>> GetLocationResponseAsync(Locations location)
        {
            var apiResponse = await _restApiClient.GetApiResponseAsync<Location>(UrlPathBuilder.GetLocationUrl((int)location));

            return apiResponse;
        }

        public async Task<ApiResponse<ClanRankingList>> GetClanRankingsResponseAsync(Locations location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanRankingList>(UrlPathBuilder.GetRankingsClanUrl((int)location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<PlayerRankingList>> GetPlayerRankingsResponseAsync(Locations location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<PlayerRankingList>(UrlPathBuilder.GetRankingsPlayerUrl((int)location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<ApiResponse<ClanWarsRankingList>> GetClanWarsRankingsResponseAsync(Locations location, LocationFilter locationFilter = null)
        {
            if (locationFilter?.After != null && locationFilter.Before != null)
            {
                throw new InvalidOperationException("Only after or before can be specified for a request, not both.");
            }

            var apiResponse = await _restApiClient.GetApiResponseAsync<ClanWarsRankingList>(UrlPathBuilder.GetRankingsClanWarUrl((int)location), locationFilter?.ToQueryParams());

            return apiResponse;
        }

        public async Task<LocationList> GetLocationsAsync(LocationFilter locationFilter = null)
        {
            var apiResponse = await GetLocationsResponseAsync(locationFilter);

            return apiResponse.GetModel();
        }

        public async Task<Location> GetLocationAsync(Locations location)
        {
            var apiResponse = await GetLocationResponseAsync(location);

            return apiResponse.GetModel();
        }

        public async Task<ClanRankingList> GetClanRankingsAsync(Locations location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetClanRankingsResponseAsync(location, locationFilter);

            return apiResponse.GetModel();
        }

        public async Task<PlayerRankingList> GetPlayerRankingsAsync(Locations location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetPlayerRankingsResponseAsync(location, locationFilter);

            return apiResponse.GetModel();
        }

        public async Task<ClanWarsRankingList> GetClanWarsRankingsAsync(Locations location, LocationFilter locationFilter = null)
        {
            var apiResponse = await GetClanWarsRankingsResponseAsync(location, locationFilter);

            return apiResponse.GetModel();
        }
    }
}
