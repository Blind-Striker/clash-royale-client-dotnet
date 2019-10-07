using Microsoft.Extensions.DependencyInjection;

using Pekka.ClashRoyaleApi.Client.Clients;
using Pekka.ClashRoyaleApi.Client.Contracts;
using Pekka.Core;
using Pekka.Core.Contracts;

using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Pekka.ClashRoyaleApi.Client.FilterModels;
using Pekka.ClashRoyaleApi.Client.Models.ClanModels;
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


            var player = "#C280JCG";
            var clan = "#Y2JPYJ";

            IApiResponse<Player> playerResponse = await playerClient.GetPlayerResponseAsync(player);
            IApiResponse<PlayerUpcomingChests> chestsResponseAsync = await playerClient.GetUpcomingChestsResponseAsync(player);
            IApiResponse<List<PlayerBattleLog>> battlesResponseAsync = await playerClient.GetBattlesResponseAsync(player);

            IApiResponse<Clan> clanResponseAsync = await clanClient.GetClanResponseAsync(clan);
            IApiResponse<Clans> searchClanResponseAsync = await clanClient.SearchClanResponseAsync(new ClanFilter() {Name = "eyyam"});
            IApiResponse<Clans> searchClanResponse2Async = await clanClient.SearchClanResponseAsync(new ClanFilter() {LocationId = (int)Locations._INT, Limit = 25});
            IApiResponse<Clans> searchClanResponse3Async = await clanClient.SearchClanResponseAsync(new ClanFilter() {LocationId = (int)Locations._INT, Limit = 25, MaxMembers = 10});

            IApiResponse<ClanMembers> membersResponseAsync = await clanClient.GetMembersResponseAsync(clan);
            IApiResponse<ClanMembers> membersResponse2Async = await clanClient.GetMembersResponseAsync(clan, new ClanMemberFilter(){Limit = 10});

            IApiResponse<ClanWarLogs> warLogResponseAsync = await clanClient.GetWarLogResponseAsync(clan);
            IApiResponse<ClanWarLogs> warLogResponse2Async = await clanClient.GetWarLogResponseAsync(clan, new ClanWarLogFilter() {Limit = 5});
        }
    }
}