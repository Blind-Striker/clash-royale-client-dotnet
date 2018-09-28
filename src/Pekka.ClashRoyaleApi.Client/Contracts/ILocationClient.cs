using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ILocationClient
    {
        Task<ApiResponse<LocationList>> GetLocationsResponseAsync(LocationFilter locationApiFilter = null);
        Task<ApiResponse<Location>> GetLocationResponseAsync(Locations location);
        Task<ApiResponse<ClanRankingList>> GetClanRankingsResponseAsync(Locations location, LocationFilter locationApiFilter = null);
        Task<ApiResponse<PlayerRankingList>> GetPlayerRankingsResponseAsync(Locations location, LocationFilter locationApiFilter = null);
        Task<ApiResponse<ClanWarsRankingList>> GetClanWarsRankingsResponseAsync(Locations location, LocationFilter locationApiFilter = null);
        Task<LocationList> GetLocationsAsync(LocationFilter locationApiFilter = null);
        Task<Location> GetLocationAsync(Locations location);
        Task<ClanRankingList> GetClanRankingsAsync(Locations location, LocationFilter locationApiFilter = null);
        Task<PlayerRankingList> GetPlayerRankingsAsync(Locations location, LocationFilter locationApiFilter = null);
        Task<ClanWarsRankingList> GetClanWarsRankingsAsync(Locations location, LocationFilter locationApiFilter = null);
    }
}