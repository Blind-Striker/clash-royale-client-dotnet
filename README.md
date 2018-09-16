# Clash Royale .NET Client Library

.NET client library for accessing unofficial [Clash Royale API](https://royaleapi.com/)

Built using .NET Standard 2. Supports .NET Framework , .NET Core 2.0 runtimes, .NET Core 2.1 runtimes.

All API requests must be accompanied by a developer key. You can learn how to obtain and manage your developer key on [Royale Api Website](https://docs.royaleapi.com/#/authentication?id=key-management).

## Features
- Depedency injection friendly (can also be used standalone, see below)
- Supports async

## Builds status

|       | Linux | Windows |
|-------|-------|----------|
| Build | [![Build Status](https://travis-ci-job-status.herokuapp.com/badge/Blind-Striker/clash-royale-client-dotnet/master/linux)](https://travis-ci.org/Blind-Striker/clash-royale-client-dotnet)      | [![Build status](https://ci.appveyor.com/api/projects/status/ogciqii9ek7na1oa?svg=true)](https://ci.appveyor.com/project/Blind-Striker/clash-royale-client-dotnet)     |

## Installation

[![NuGet](https://img.shields.io/nuget/v/RoyaleApi.Client.svg)](https://www.nuget.org/packages/RoyaleApi.Client)

To install RoyaleApi.Client, run the following command in the Package Manager Console

```
Install-Package RoyaleApi.Client
```

Or use `dotnet cli`

```
dotnet add package RoyaleApi.Client
```

# Usage

It can be used with any DI library, or it can be used standalone.

## Standalone Initialization

If you do not want to use any DI framework, you have to instantiate RoyaleApiStandalone as follows.

```csharp
    ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");
    var apiClientContext = RoyaleApiStandalone.Create(apiOptions);
    IPlayerClient playerClient = apiClientContext.PlayerClient;
    IClanClient clanClient = apiClientContext.ClanClient;
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

## License
Licensed under Apache 2.0, see [LICENSE](LICENSE) for the full text.
