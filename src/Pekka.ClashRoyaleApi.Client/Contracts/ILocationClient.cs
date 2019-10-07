using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Threading.Tasks;

using LocationEnum = Pekka.Core.Locations;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ILocationClient : ILocationClientWithApiResponse, ILocationClientModel
    {
    }

    public interface ILocationClientWithApiResponse
    {
        Task<IApiResponse<List<Location>>> GetLocationsResponseAsync(LocationFilter locationApiFilter = null);

        Task<IApiResponse<Location>> GetLocationResponseAsync(LocationEnum location);

        Task<IApiResponse<LocationRankingClans>> GetClanRankingsResponseAsync(LocationEnum location, LocationFilter locationApiFilter = null);

        Task<IApiResponse<LocationRankingPlayers>> GetPlayerRankingsResponseAsync(LocationEnum location, LocationFilter locationApiFilter = null);

        Task<IApiResponse<LocationRankingClanWars>> GetClanWarsRankingsResponseAsync(LocationEnum location, LocationFilter locationApiFilter = null);
    }

    public interface ILocationClientModel
    {
        Task<List<Location>> GetLocationsAsync(LocationFilter locationApiFilter = null);

        Task<Location> GetLocationAsync(LocationEnum location);

        Task<LocationRankingClans> GetClanRankingsAsync(LocationEnum location, LocationFilter locationApiFilter = null);

        Task<LocationRankingPlayers> GetPlayerRankingsAsync(LocationEnum location, LocationFilter locationApiFilter = null);

        Task<LocationRankingClanWars> GetClanWarsRankingsAsync(LocationEnum location, LocationFilter locationApiFilter = null);
    }
}