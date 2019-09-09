using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core;
using Pekka.Core.Responses;

using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ILocationClient
    {
        Task<IApiResponse<LocationList>> GetLocationsResponseAsync(LocationFilter locationApiFilter = null);

        Task<IApiResponse<Location>> GetLocationResponseAsync(Locations location);

        Task<IApiResponse<ClanRankingList>> GetClanRankingsResponseAsync(Locations location,
            LocationFilter locationApiFilter = null);

        Task<IApiResponse<PlayerRankingList>> GetPlayerRankingsResponseAsync(Locations location,
            LocationFilter locationApiFilter = null);

        Task<IApiResponse<ClanWarsRankingList>> GetClanWarsRankingsResponseAsync(Locations location,
            LocationFilter locationApiFilter = null);

        Task<LocationList> GetLocationsAsync(LocationFilter locationApiFilter = null);

        Task<Location> GetLocationAsync(Locations location);

        Task<ClanRankingList> GetClanRankingsAsync(Locations location, LocationFilter locationApiFilter = null);

        Task<PlayerRankingList> GetPlayerRankingsAsync(Locations location, LocationFilter locationApiFilter = null);

        Task<ClanWarsRankingList> GetClanWarsRankingsAsync(Locations location, LocationFilter locationApiFilter = null);
    }
}