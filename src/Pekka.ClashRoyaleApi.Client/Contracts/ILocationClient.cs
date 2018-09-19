using System.Threading.Tasks;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.Core;
using Pekka.Core.Responses;

namespace Pekka.ClashRoyaleApi.Client.Contracts
{
    public interface ILocationClient
    {
        Task<ApiResponse<LocationList>> GetLocationsResponseAsync(LocationFilter locationFilter = null);
        Task<ApiResponse<Location>> GetLocationResponseAsync(Locations location);
        Task<ApiResponse<ClanRankingList>> GetClanRankingsResponseAsync(Locations location, LocationFilter locationFilter = null);
        Task<ApiResponse<PlayerRankingList>> GetPlayerRankingsResponseAsync(Locations location, LocationFilter locationFilter = null);
        Task<ApiResponse<ClanWarsRankingList>> GetClanWarsRankingsResponseAsync(Locations location, LocationFilter locationFilter = null);
        Task<LocationList> GetLocationsAsync(LocationFilter locationFilter = null);
        Task<Location> GetLocationAsync(Locations location);
        Task<ClanRankingList> GetClanRankingsAsync(Locations location, LocationFilter locationFilter = null);
        Task<PlayerRankingList> GetPlayerRankingsAsync(Locations location, LocationFilter locationFilter = null);
        Task<ClanWarsRankingList> GetClanWarsRankingsAsync(Locations location, LocationFilter locationFilter = null);
    }
}