using System;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RoyaleApi.Client;
using RoyaleApi.Client.Clients;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Models;

namespace RoyaleApi.Sandbox
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ApiOptions apiOptions =
                new ApiOptions(
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MTY5MCwiaWRlbiI6IjQ5MDUwNjcyNzU5MTExNjgwMyIsIm1kIjp7fSwidHMiOjE1MzcwMTY0NTE3MDZ9.9tPpWG86V6PmGXW0kAxE9lhYIisIH8DM8NitRfaNpKY",
                    "https://api.royaleapi.com/");

            var services = new ServiceCollection();
            services.AddHttpClient<IRoyaleApiClient, RoyaleApiClient>();

            ContainerBuilder containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(services);

            containerBuilder.RegisterInstance(apiOptions);
            containerBuilder.RegisterType<PlayerClient>().As<IPlayerClient>();
            containerBuilder.RegisterType<ClanClient>().As<IClanClient>();
            containerBuilder.RegisterType<VersionClient>().As<IVersionClient>();

            var container = containerBuilder.Build();

            var playerClient = container.Resolve<IPlayerClient>();
            var clanClient = container.Resolve<IClanClient>();
            var versionClient = container.Resolve<IVersionClient>();

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

            var clans = await clanClient.GetClansResponseAsync(clanList);

            foreach (var clanTag in clanList)
            {
                var clanResult = await clanClient.GetClanResponseAsync(clanTag);

                var clan = await clanClient.GetBattlesResponseAsync(clanTag);
                var clanAll = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.All);
                var clanMate = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.ClanMate);
                var clanWar = await clanClient.GetBattlesResponseAsync(clanTag, ClanBattleType.War);

                var warResponse = await clanClient.GetWarResponseAsync(clanTag);
                var warlogs = await clanClient.GetWarLogsResponseAsync(clanTag);
                var tracking = await clanClient.GetTrackingResponseAsync(clanTag);
            }
        }
    }
}
