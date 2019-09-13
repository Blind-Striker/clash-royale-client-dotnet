using Microsoft.Extensions.DependencyInjection;

using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;
using Pekka.RoyaleApi.Client.Models.PlayerModels;
using Pekka.RoyaleApi.Client.Standalone;
using System;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Sandbox
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            string token = Environment.GetEnvironmentVariable("ROYALE_API_TOKEN");

            //var apiOptions = new ApiOptions(token, "https://api-v2.royaleapi.com/");
            var apiOptions = new ApiOptions(token, "https://api.royaleapi.com/");

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
            services.AddTransient<IVersionClient, VersionClient>();
            services.AddTransient<IConstantClient, ConstantClient>();
            //services.AddTransient<ITournamentClient, TournamentClient>();

            ServiceProvider buildServiceProvider = services.BuildServiceProvider();

            IRoyaleApiClientContext royaleApiClientContext = RoyaleApiStandalone.Create(apiOptions);
            IVersionClient versionClient = royaleApiClientContext.VersionClient;
            IClanClient clanClient = royaleApiClientContext.ClanClient;
            IPlayerClient playerClient = royaleApiClientContext.PlayerClient;

            //var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            //var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            //var versionClient = buildServiceProvider.GetRequiredService<IVersionClient>();
            //var constantClient = buildServiceProvider.GetRequiredService<IConstantClient>();
            //var restApiClient = buildServiceProvider.GetRequiredService<IRestApiClient>();
            //var tournamentClient = buildServiceProvider.GetRequiredService<ITournamentClient>();

            string[] playerList = { "C280JCG", "JGL2LGQ8", "JUQUG92Q", "JLQVYCV", "2P080VG0", "R0LR9RUQ", "Q8UUJ0JJ", "PYLQLCL8" };
            string[] clanList = { "Y2JPYJ", "282GJC9J", "9CQ2R8UY", "9C2YLQL" };


            var version = await versionClient.GetVersionResponseAsync();
            //var constantsResponseAsync = await constantClient.GetConstantsResponseAsync();

            var playerCurrent = await playerClient.GetPlayerResponseAsync(playerList[0]);
            var playerCurrentBattle = await playerClient.GetBattlesResponseAsync(playerList[0]);
            var playerCurrentChest = await playerClient.GetChestResponseAsync(playerList[0]);
            var clanResponseAsync = await clanClient.GetClanResponseAsync(clanList[0]);
            var battlesResponseAsync = await clanClient.GetBattlesResponseAsync("9PJ82CRC");
            var searchClanResponseAsync = await clanClient.SearchClanResponseAsync(new ClanSummaryFilter() { Name = "Eyy", Max = 10 });

            var eyyamWars = await clanClient.GetWarResponseAsync("Y2JPYJ");
            var warrs = await clanClient.GetWarResponseAsync("9PJ82CRC");

            var eyyamWarLogs = await clanClient.GetWarLogsResponseAsync("Y2JPYJ");
            var warrsLogs = await clanClient.GetWarLogsResponseAsync("9PJ82CRC");



            //var openTournamentResponse = await tournamentClient.GetOpenTournamentsResponseAsync();
            //var one1KTournamentResponse = await tournamentClient.Get1KTournamentsResponseAsync();
            //var fullTournamentResponse = await tournamentClient.GetFullTournamentsResponseAsync();
            //var inPrepTournamentResponse = await tournamentClient.GetInPrepTournamentsResponseAsync();
            //var joinableTournamentResponse = await tournamentClient.GetJoinableTournamentsResponseAsync();
            //var knowTournamentResponse = await tournamentClient.GetKnownTournamentsResponseAsync();

            foreach (string playerTag in playerList)
            {
                var player = await playerClient.GetPlayerResponseAsync(playerTag);

                var playerClanless = await playerClient.GetPlayerResponseAsync(playerTag,
                    new PlayerFilter() {Excludes = new Expression<Func<Player, object>>[] {p => p.Clan}});

                var playerBattle = await playerClient.GetBattlesResponseAsync(playerTag);
                var playerChest = await playerClient.GetChestResponseAsync(playerTag);
            }

            var apiResponse = await clanClient.GetClanHistoryDailyResponseAsync("2U2GGQJ");
            var clanHistories = await clanClient.GetClanHistoryWeeklyResponseAsync("2U2GGQJ");


            var clanSummaries = await clanClient.SearchClanAsync(new ClanSummaryFilter()
                {Name = "eyyam", LocationId = (int) Locations._INT, MinMembers = 0, MaxMembers = 50});

            var clans = await clanClient.GetClansResponseAsync(clanList);

            foreach (string clanTag in clanList)
            {
                var clanResult = await clanClient.GetClanResponseAsync(clanTag);

                var clan = await clanClient.GetBattlesResponseAsync(clanTag);

                var warResponse = await clanClient.GetWarResponseAsync(clanTag);
                var warlogs = await clanClient.GetWarLogsResponseAsync(clanTag);
                var tracking = await clanClient.GetTrackingResponseAsync(clanTag);
            }
        }
    }
}