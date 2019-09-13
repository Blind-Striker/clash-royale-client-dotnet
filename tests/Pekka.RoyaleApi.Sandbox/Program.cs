using Microsoft.Extensions.DependencyInjection;

using Pekka.Core;
using Pekka.Core.Contracts;
using Pekka.RoyaleApi.Client.Clients;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.FilterModels;

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Pekka.RoyaleApi.Sandbox
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {

            string token = Environment.GetEnvironmentVariable("ROYALE_API_TOKEN");

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

            ServiceProvider buildServiceProvider = services.BuildServiceProvider();

            var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            var versionClient = buildServiceProvider.GetRequiredService<IVersionClient>();
            var constantClient = buildServiceProvider.GetRequiredService<IConstantClient>();
            var restApiClient = buildServiceProvider.GetRequiredService<IRestApiClient>();

            string[] playerList = { "C280JCG", "JGL2LGQ8", "JUQUG92Q", "JLQVYCV", "2P080VG0", "R0LR9RUQ", "Q8UUJ0JJ", "PYLQLCL8" };
            string[] clanList = { "Y2JPYJ", "282GJC9J", "9CQ2R8UY", "9C2YLQL" };

            var versionResponse = await versionClient.GetVersionResponseAsync();
            var constantsResponse = await constantClient.GetConstantsResponseAsync();

            var playerCurrent = await playerClient.GetPlayerResponseAsync(playerList[0]);
            var playerCurrentBattle = await playerClient.GetBattlesResponseAsync(playerList[0]);
            var playerCurrentChest = await playerClient.GetChestResponseAsync(playerList[0]);

            var clanResponse = await clanClient.GetClanResponseAsync(clanList[0]);
            var battlesResponse = await clanClient.GetBattlesResponseAsync("9PJ82CRC");
            var searchClanResponse = await clanClient.SearchClanResponseAsync(new ClanSummaryFilter() { Name = "Eyy", Max = 10 });

            var eyyamWars = await clanClient.GetWarResponseAsync("Y2JPYJ");
            var warrs = await clanClient.GetWarResponseAsync("9PJ82CRC");
            var eyyamWarLogs = await clanClient.GetWarLogsResponseAsync("Y2JPYJ");
            var warrsLogs = await clanClient.GetWarLogsResponseAsync("9PJ82CRC");
        }
    }
}