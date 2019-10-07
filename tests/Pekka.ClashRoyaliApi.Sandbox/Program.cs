using Microsoft.Extensions.DependencyInjection;

using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core;
using Pekka.Core.Contracts;

using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.Models.PlayerModels;
using Pekka.Core.Responses;

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

            ServiceProvider buildServiceProvider = services.BuildServiceProvider();

            var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
            var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
            var tournamentClient = buildServiceProvider.GetRequiredService<ITournamentClient>();
            var cardClient = buildServiceProvider.GetRequiredService<ICardClient>();
            var locationClient = buildServiceProvider.GetRequiredService<ILocationClient>();


            IApiResponse<Player> playerResponse = await playerClient.GetPlayerResponseAsync("#C280JCG");
        }
    }
}