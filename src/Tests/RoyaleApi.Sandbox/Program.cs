using System;
using System.Net.Http;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using RoyaleApi.Client;
using RoyaleApi.Client.Clients;
using RoyaleApi.Client.Contracts;

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

            var container = containerBuilder.Build();

            var playerClient = container.Resolve<IPlayerClient>();

            //var apiResponse = await playerClient.GetPlayersAsync("C280JCG", "8L9L9GL", "L88P2282", "9CQ2U8QJ");
            //var apiResponse = await playerClient.GetBattlesAsync("C280JCG", "8L9L9GL", "L88P2282", "9CQ2U8QJ");

            var apiResponse = await playerClient.GetChestAsync("C280JCG");
            var apiResponse2 = await playerClient.GetChestsAsync("C280JCG", "8L9L9GL", "L88P2282", "9CQ2U8QJ");
        }
    }
}
