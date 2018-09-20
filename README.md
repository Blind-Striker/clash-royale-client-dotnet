# P.E.K.K.A - Clash Royale API (official) and Royale API (unofficial) Client Library Client for .NET

P.E.K.K.A is a client library targeting .NET Standard 2.0 and .NET 4.6.1 that provides an easy way to interact with both official [Clash Royale API](https://developer.clashroyale.com) and unofficial public API [Royale API](https://royaleapi.com/)

All API requests must be accompanied by a developer key. You need to register then create a key for Clash Royale API (official) on [Clash Royale API Website](https://developer.clashroyale.com). You can learn how to obtain and manage your developer key for Royale API (unofficial) on [Royale API Website](https://docs.royaleapi.com/#/authentication?id=key-management).

## Supported Platforms

* .NET 4.6.1 (Desktop / Server)
* [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Features
* Depedency injection friendly (can also be used standalone, see below)
* Supports async and sync (via extension method, see below) calls.

## Builds status

|       | Linux | Windows |
|-------|-------|----------|
| Build | [![Build Status](https://travis-ci-job-status.herokuapp.com/badge/Blind-Striker/clash-royale-client-dotnet/master/linux)](https://travis-ci.org/Blind-Striker/clash-royale-client-dotnet)      | [![Build status](https://ci.appveyor.com/api/projects/status/ogciqii9ek7na1oa?svg=true)](https://ci.appveyor.com/project/Blind-Striker/clash-royale-client-dotnet)     |

## Installation

|       | Logo | Package |
|-------|-------|----------|
| P.E.K.K.A Clash Royale API (official) | <img src="https://www.codefiction.tech/assets/pekka-clash-royale-api-logo.png" width="150" height="150" title="Github Logo">    | [![NuGet](https://img.shields.io/nuget/v/Pekka.ClashRoyaleApi.Client.svg)](https://www.nuget.org/packages/RoyaleApi.Client)     |
| P.E.K.K.A Royale API (unofficial) | <img src="https://www.codefiction.tech/assets/pekka-royale-api-logo.png" width="150" height="150" title="Github Logo">     | [![NuGet](https://img.shields.io/nuget/v/Pekka.RoyaleApi.Client.svg)](https://www.nuget.org/packages/RoyaleApi.Client)    |


Following commands can be use too install both Pekka.ClashRoyaleApi.Client and Pekka.RoyaleApi.Client, run the following command in the Package Manager Console

```
Install-Package Pekka.ClashRoyaleApi.Client
Install-Package Pekka.RoyaleApi.Client
```

Or use `dotnet cli`

```
dotnet Pekka.ClashRoyaleApi.Client
dotnet Pekka.RoyaleApi.Client
```
# Usage

The usage of both Pekka.ClashRoyaleApi.Client and Pekka.RoyaleApi.Client libraries is similar. And both can be used with any DI library, or it can be used standalone.

## Standalone Initialization

If you do not want to use any DI framework, you have to instantiate `ClashRoyaleApiStandalone` or `RoyaleApiStandalone` as follows.

### RoyaleApiStandalone
```csharp
ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");
var apiClientContext = RoyaleApiStandalone.Create(apiOptions);
IPlayerClient playerClient = apiClientContext.PlayerClient;
IClanClient clanClient = apiClientContext.ClanClient;
IVersionClient clanClient = apiClientContext.VersionClient;
```

### ClashRoyaleApiStandalone
```csharp
ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.clashroyale.com/v1/");
var apiClientContext = ClashRoyaleApiStandalone.Create(apiOptions);
IPlayerClient playerClient = apiClientContext.PlayerClient;
IClanClient clanClient = apiClientContext.ClanClient;
ITournamentClient tournamentClient = apiClientContext.TournamentClient;
ICardClient cardClient = apiClientContext.CardClient;
ILocationClient locationClient = apiClientContext.LocationClient;
```

`apiClientContext` contains all necessary clients.

## Microsoft.Extensions.DependencyInjection Initialization

First you need to install `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Http` nuget package as follows

```
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Http
```

By installing `Microsoft.Extensions.Http` you will be able to use [`HttpClientFactory`](https://www.stevejgordon.co.uk/introduction-to-httpclientfactory-aspnetcore).In the words of the ASP.NET Team it is “an opinionated factory for creating HttpClient instances” and is a new feature comes with the release of ASP.NET Core 2.1. 

If you don't want to use `HttpClientFactory`, you must register `HttpClient` yourself with the container.

Register necessary depedencies to `ServiceCollection` as follows

```csharp
ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");

var services = new ServiceCollection();
services.AddSingleton(apiOptions);
services.AddHttpClient<IRoyaleApiClient, RoyaleApiClient>();
services.AddTransient<IPlayerClient, PlayerClient>();
services.AddTransient<IClanClient, ClanClient>();
services.AddTransient<IVersionClient, VersionClient>();

var buildServiceProvider = services.BuildServiceProvider();

var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
var versionClient = buildServiceProvider.GetRequiredService<IVersionClient>();
```

## Synchronous Wrappers

For synchronous calls Task extension method `RunSync` can be used. 

```csharp
var player = playerClient.GetPlayerResponseAsync(playerTag).RunSync(); ;
```

But there is a possibility that this extension method can't cover all cases. See Stackoverflow [article](https://stackoverflow.com/a/25097498/1577827)

## License
Licensed under Apache 2.0, see [LICENSE](LICENSE) for the full text.
