﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;

namespace Pekka.RoyaleApi.Sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");

            var services = new ServiceCollection();
            services.AddSingleton(apiOptions);
            services.AddHttpClient<IRestApiClient, RestApiClient>();
            services.AddTransient<IPlayerClient, PlayerClient>();
            services.AddTransient<IClanClient, ClanClient>();
            services.AddTransient<IVersionClient, VersionClient>();

            var buildServiceProvider = services.BuildServiceProvider();

            var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            var versionClient = buildServiceProvider.GetRequiredService<IVersionClient>();

            //ContainerBuilder containerBuilder = new ContainerBuilder();
            //containerBuilder.Populate(services);

            //containerBuilder.RegisterInstance(apiOptions);
            //containerBuilder.RegisterType<PlayerClient>().As<IPlayerClient>();
            //containerBuilder.RegisterType<ClanClient>().As<IClanClient>();
            //containerBuilder.RegisterType<VersionClient>().As<IVersionClient>();

            //var container = containerBuilder.Build();

            //var playerClient = container.Resolve<IPlayerClient>();
            //var clanClient = container.Resolve<IClanClient>();
            //var versionClient = container.Resolve<IVersionClient>();

            var version = await versionClient.GetVersion();

            string[] playerList = {"C280JCG", "JGL2LGQ8", "JUQUG92Q", "JLQVYCV", "2P080VG0", "R0LR9RUQ", "Q8UUJ0JJ", "PYLQLCL8" };
            string[] clanList = {"Y2JPYJ", "282GJC9J", "9CQ2R8UY", "9C2YLQL"};

            var popularPlayersResponse = await playerClient.GetPopularPlayersResponseAsync();
            var topPlayers = await playerClient.GetTopPlayersResponseAsync(Locations.TR);

            var players = await playerClient.GetPlayersResponseAsync(playerList);
            var battles = await playerClient.GetBattlesResponseAsync(playerList);
            var chests = await playerClient.GetChestsResponseAsync(playerList);

            foreach (var playerTag in playerList)
            {
                var player = await playerClient.GetPlayerResponseAsync(playerTag);
                var playerBattle = await playerClient.GetBattlesResponseAsync(playerTag);
                var playerChest = await playerClient.GetChestResponseAsync(playerTag);
            }

            var apiResponse = await clanClient.GetClanHistoryDailyResponseAsync("2U2GGQJ");
            var clanHistories = await clanClient.GetClanHistoryWeeklyResponseAsync("2U2GGQJ");
            var topClans = await clanClient.GetTopClansResponseAsync(Locations._INT, new Pagination(){Max = 10});
            var response = await clanClient.GetPopularPlayersResponseAsync(new Pagination() { Max = 10 });
            await clanClient.GetGetTopWarClanWarsResponseAsync(Locations._INT, new Pagination() { Max = 10 });


            var clanSummaries = await clanClient.SearchClanAsync(new ClanFilter() { Name = "eyyam", LocationId = (int)Locations._INT, MinMembers = 0, MaxMembers = 50 });

            var clans = await clanClient.GetClansResponseAsync(clanList);

            foreach (var clanTag in clanList)
            {
                var clanResult = await clanClient.GetClanResponseAsync(clanTag);

                var clan = await clanClient.GetBattlesResponseAsync(clanTag);
                //var clanAll = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.All);
                //var clanMate = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.ClanMate);
                //var clanWar = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.War);

                var warResponse = await clanClient.GetWarResponseAsync(clanTag);
                var warlogs = await clanClient.GetWarLogsResponseAsync(clanTag);
                var tracking = await clanClient.GetTrackingResponseAsync(clanTag);
            }
        }
    }
}
