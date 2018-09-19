using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.Core;
using Pekka.Core.Contracts;

namespace Pekka.ClashRoyaliApi.Sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ApiOptions apiOptions = new ApiOptions("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImZlOWYwMjcwLTJkNzQtNDBiNy05MzQyLWM4YTA4ZTJkMjAyNSIsImlhdCI6MTUzNzE4ODYxNywic3ViIjoiZGV2ZWxvcGVyLzdlYTBkNDk0LWVkY2ItOTFmMC05NGJiLWNhMWM4ZjJhMDk4ZiIsInNjb3BlcyI6WyJyb3lhbGUiXSwibGltaXRzIjpbeyJ0aWVyIjoiZGV2ZWxvcGVyL3NpbHZlciIsInR5cGUiOiJ0aHJvdHRsaW5nIn0seyJjaWRycyI6WyI4Mi4yMjIuNDcuMTIyIl0sInR5cGUiOiJjbGllbnQifV19.d7oXuWh2oXgcJNhTbDKuVQh0beCA6v5E_yMpDh4carRdhgE8NEo81pU7wxVpoj_0Uz0RiJjm7Ub47xOsiUwwPQ", "https://api.clashroyale.com/v1/");

            var services = new ServiceCollection();
            services.AddSingleton(apiOptions);
            services.AddHttpClient<IRestApiClient, RestApiClient>();
            services.AddTransient<IPlayerClient, PlayerClient>();
            services.AddTransient<IClanClient, ClanClient>();
            services.AddTransient<ITournamentClient, TournamentClient>();
            services.AddTransient<ICardClient, CardClient>();
            services.AddTransient<ILocationClient, LocationClient>();

            var buildServiceProvider = services.BuildServiceProvider();

            var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            var tournamentClient = buildServiceProvider.GetRequiredService<ITournamentClient>();
            var cardClient = buildServiceProvider.GetRequiredService<ICardClient>();
            var locationClient = buildServiceProvider.GetRequiredService<ILocationClient>();

            // ApiResponse<PlayerDetail> apiResponse = await playerClient.GetPlayerResponseAsync("#C280JCG");

            // var response = await playerClient.GetUpcomingChestsResponseAsync("#C280JCG");

            //var apiResponse =
            //    await clanClient.SearchClanResponseAsync(new ClanFilter()
            //    {
            //        Name = "Eyyam",
            //        LocationId = 57000006
            //    });

            //var tag = apiResponse.Model.Items[0].Tag;

            //var clanResponse = await clanClient.GetClanResponseAsync(tag);
            //var membersResponse = await clanClient.GetMembersResponseAsync(tag);
            //var warlogResponse = await clanClient.GetWarlogResponseAsync(tag);
            //var currentWarResponse = await clanClient.GetCurrentWarResponseAsync(tag);

            //var apiResponse = await tournamentClient.SearchTournamentResponseAsync(new TournamentFilter() {Limit = 10, Name = "deniz"});

            //var apiResponse = await cardClient.GetCardsResponseAsync();

            var apiResponse = await locationClient.GetLocationsResponseAsync();
            var api10Response = await locationClient.GetLocationsResponseAsync(new LocationFilter(){Limit = 10});

            var locationResponse = await locationClient.GetLocationResponseAsync(Locations._INT);
            var clanRankingsResponse = await locationClient.GetClanRankingsResponseAsync(Locations._INT, new LocationFilter() { Limit = 10 });
            var playerRankingsResponse = await locationClient.GetPlayerRankingsResponseAsync(Locations._INT, new LocationFilter() { Limit = 10 });
            var clanWarsRankingsResponse = await locationClient.GetClanWarsRankingsResponseAsync(Locations._INT, new LocationFilter() { Limit = 10 });
        }
    }
}
