using Microsoft.Extensions.DependencyInjection;

using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.CardModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
using Pekka.ClashRoyaleApi.Client.Models.GlobalTournamentModels;
using Pekka.ClashRoyaleApi.Client.Models.LocationModels;
using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.ClashRoyaleApi.Client.Models.TournamentModels;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.Core.Responses;

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pekka.ClashRoyaleApi.Sandbox
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            string token = Environment.GetEnvironmentVariable("CLASH_API_TOKEN");

            var apiOptions = new ApiOptions(token, "https://api.clashroyale.com/v1/");

            var services = new ServiceCollection();
            services.AddSingleton(apiOptions);

            services.AddHttpClient<IRestApiClient, RestApiClient>((provider, client) =>
            {
                var options = provider.GetRequiredService<ApiOptions>();
                client.BaseAddress = new Uri(options.BaseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", options.BearerToken);
            });

            services.AddTransient<IPlayerClient, PlayerClient>();
            services.AddTransient<IClanClient, ClanClient>();
            services.AddTransient<ITournamentClient, TournamentClient>();
            services.AddTransient<ICardClient, CardClient>();
            services.AddTransient<ILocationClient, LocationClient>();
            services.AddTransient<IGlobalTournamentClient, GlobalTournamentClient>();

            ServiceProvider buildServiceProvider = services.BuildServiceProvider();

            var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            var tournamentClient = buildServiceProvider.GetRequiredService<ITournamentClient>();
            var cardClient = buildServiceProvider.GetRequiredService<ICardClient>();
            var locationClient = buildServiceProvider.GetRequiredService<ILocationClient>();
            var globalTournamentClient = buildServiceProvider.GetRequiredService<IGlobalTournamentClient>();

            var playerTag = "#C280JCG";
            var clanTag = "#Y2JPYJ";
            var tournamentTag = "#22QGPCLU";

            IApiResponse<Player> playerResponse = await playerClient.GetPlayerResponseAsync(playerTag);
            Player playerAsync = await playerClient.GetPlayerAsync(playerTag);
            IApiResponse<PlayerUpcomingChests> chestsResponseAsync = await playerClient.GetUpcomingChestsResponseAsync(playerTag);
            IApiResponse<List<PlayerBattleLog>> battlesResponseAsync = await playerClient.GetBattlesResponseAsync(playerTag);

            IApiResponse<Clan> clanResponseAsync = await clanClient.GetClanResponseAsync(clanTag);
            IApiResponse<PagedClans> searchClanResponseAsync = await clanClient.SearchClanResponseAsync(new ClanFilter() {Name = "eyyam"});
            PagedClans searchClanAsync = await clanClient.SearchClanAsync(new ClanFilter() {Name = "eyyam"});

            IApiResponse<PagedClans> searchClanResponse2Async = await clanClient.SearchClanResponseAsync(new ClanFilter() {LocationId = (int) LocationsEnum._INT, Limit = 25});
            IApiResponse<PagedClans> searchClanResponse3Async =await clanClient.SearchClanResponseAsync(new ClanFilter() {LocationId = (int) LocationsEnum._INT, Limit = 25, MaxMembers = 10});

            IApiResponse<PagedClanMembers> membersResponseAsync = await clanClient.GetMembersResponseAsync(clanTag);
            IApiResponse<PagedClanMembers> membersResponse2Async = await clanClient.GetMembersResponseAsync(clanTag, new ClanMemberFilter() {Limit = 10});

            IApiResponse<PagedClanWarLogs> warLogResponseAsync = await clanClient.GetWarLogResponseAsync(clanTag);
            IApiResponse<PagedClanWarLogs> warLogResponse2Async = await clanClient.GetWarLogResponseAsync(clanTag, new ClanWarLogFilter() {Limit = 5});

            IApiResponse<ClanCurrentWar> currentWarResponseAsync = await clanClient.GetCurrentWarResponseAsync(clanTag);

            IApiResponse<PagedTournaments> searchTournamentResponseAsync = await tournamentClient.SearchTournamentResponseAsync(new TournamentFilter() {Name = "Hel"});
            IApiResponse<Tournament> tournamentResponseAsync = await tournamentClient.GetTournamentResponseAsync(tournamentTag);

            IApiResponse<PagedCards> cardsResponseAsync = await cardClient.GetCardsResponseAsync();

            IApiResponse<PagedGlobalTournaments> globalTournamentsResponseAsync = await globalTournamentClient.GetGlobalTournamentsResponseAsync();

            IApiResponse<Location> locationResponseAsync = await locationClient.GetLocationResponseAsync(LocationsEnum.TR);
            IApiResponse<PagedLocations> locationsResponseAsync = await locationClient.GetLocationsResponseAsync();
            IApiResponse<PagedLocations> locationsResponse2Async = await locationClient.GetLocationsResponseAsync(new LocationFilter() {Limit = 10});
            IApiResponse<PagedLocationRankingClans> clanRankingsResponseAsync = await locationClient.GetClanRankingsResponseAsync(LocationsEnum.TR);
            IApiResponse<PagedLocationRankingClans> clanRankingsResponse2Async = await locationClient.GetClanRankingsResponseAsync(LocationsEnum._INT, new LocationFilter() {Limit = 10});
            IApiResponse<PagedLocationRankingPlayers> playerRankingsResponseAsync = await locationClient.GetPlayerRankingsResponseAsync(LocationsEnum.DE);
            IApiResponse<PagedLocationRankingPlayers> playerRankingsResponse2Async = await locationClient.GetPlayerRankingsResponseAsync(LocationsEnum.US, new LocationFilter() {Limit = 25});
            IApiResponse<PagedLocationRankingClanWars> clanWarsRankingsResponseAsync = await locationClient.GetClanWarsRankingsResponseAsync(LocationsEnum.TR);

            IApiResponse<PagedLocationRankingClanWars> clanWarsRankingsResponse2Async = await locationClient.GetClanWarsRankingsResponseAsync(LocationsEnum.GB, new LocationFilter() {Limit = 5});
        }
    }
}