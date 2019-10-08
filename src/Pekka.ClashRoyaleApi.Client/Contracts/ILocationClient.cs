using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

using Pekka.Core;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ILocationClient : ILocationClientWithApiResponse, ILocationClientModel
    {
    }

    public interface ILocationClientWithApiResponse
    {
        Task<IApiResponse<PagedLocations>> GetLocationsResponseAsync(LocationFilter locationApiFilter = null);

        Task<IApiResponse<Location>> GetLocationResponseAsync(LocationsEnum locationEnum);

        Task<IApiResponse<PagedLocationRankingClans>> GetClanRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);

        Task<IApiResponse<PagedLocationRankingPlayers>> GetPlayerRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);

        Task<IApiResponse<PagedLocationRankingClanWars>> GetClanWarsRankingsResponseAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);
    }

    public interface ILocationClientModel
    {
        Task<PagedLocations> GetLocationsAsync(LocationFilter locationApiFilter = null);

        Task<Location> GetLocationAsync(LocationsEnum locationEnum);

        Task<PagedLocationRankingClans> GetClanRankingsAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);

        Task<PagedLocationRankingPlayers> GetPlayerRankingsAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);

        Task<PagedLocationRankingClanWars> GetClanWarsRankingsAsync(LocationsEnum locationEnum, LocationFilter locationApiFilter = null);
    }
}