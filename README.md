# P.E.K.K.A - Clash Royale API (official) and Royale API (unofficial) Client Library for .NET

P.E.K.K.A is a client library (C# wrapper) targeting .NET Standard 2.0 and .NET 4.6.1 that provides an easy way to interact with both official [Clash Royale API](https://developer.clashroyale.com) and unofficial public API [Royale API](https://royaleapi.com/)

All API requests must be accompanied by a developer key. You need to register then create a key for Clash Royale API (official) on [Clash Royale API Website](https://developer.clashroyale.com). You can learn how to obtain and manage your developer key for Royale API (unofficial) on [Royale API Website](https://docs.royaleapi.com/#/authentication?id=key-management).

|                         | Stable                                                                                                                                  | Nightly                                                                                                                                                                                                                 |
| ----------------------- | --------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Clash Royale API Client | [![NuGet](https://img.shields.io/nuget/v/Pekka.ClashRoyaleApi.Client.svg)](https://www.nuget.org/packages/Pekka.ClashRoyaleApi.Client/) | [![MyGet](https://img.shields.io/myget/pekka-clashroyaleapi-client/vpre/Pekka.ClashRoyaleApi.Client.svg?label=myget)](https://www.myget.org/feed/pekka-clashroyaleapi-client/package/nuget/Pekka.ClashRoyaleApi.Client) |
| Royale API Client       | [![NuGet](https://img.shields.io/nuget/v/Pekka.RoyaleApi.Client.svg)](https://www.nuget.org/packages/Pekka.RoyaleApi.Client/)           | [![MyGet](https://img.shields.io/myget/pekka-royaleapi-client/vpre/Pekka.RoyaleApi.Client.svg?label=myget)](https://www.myget.org/feed/pekka-royaleapi-client/package/nuget/Pekka.RoyaleApi.Client)                     |

## Supported Platforms

- .NET 4.6.1 (Desktop / Server)
- [.NET Standard 2.0](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Features

- Dependency injection friendly (can also be used standalone, see below)
- Supports async and sync (via extension method, see below) calls.

## Continuous integration

| Client Library    | Platform | Build Server    | Build Status                                                                                                                                                                                                                              | Integration Tests |
| ----------------- | -------- | --------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------- |
| Royale API Client | Windows  | Azure Pipelines | [![Build Status](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_apis/build/status/Windows?branchName=master)](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_build/latest?definitionId=9&branchName=master) |                   |
| Royale API Client | Ubuntu   | Azure Pipelines | [![Build Status](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_apis/build/status/Ubuntu?branchName=master)](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_build/latest?definitionId=8&branchName=master)  |                   |
| Royale API Client | MacOS    | Azure Pipelines | [![Build Status](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_apis/build/status/macOS?branchName=master)](https://dev.azure.com/denizirgindev/localstack-dotnet-client/_build/latest?definitionId=10&branchName=master)  |                   |
| Royale API Client | Linux    | Travis          | [![Build Status](https://travis-ci.org/Blind-Striker/clash-royale-client-dotnet.svg?branch=master) ](https://travis-ci.org/Blind-Striker/clash-royale-client-dotnet)                                                                      |                   |
| Royale API Client | Windows  | AppVeyor        | [![Build status](https://ci.appveyor.com/api/projects/status/ogciqii9ek7na1oa?svg=true) ](https://ci.appveyor.com/project/Blind-Striker/clash-royale-client-dotnet)                                                                       |                   |

## Table of Contents

1. [Installation](#installation)
2. [Usage](#usage)
   - [Standalone Initialization](#standalone-initialization)
     - [Royale Api Standalone](#royaleapistandalone)
     - [Clash Royale Api Standalone](#clashroyaleapistandalone)
   - [Microsoft.Extensions.DependencyInjection Initialization](#microsoftextensionsdependencyinjection-initialization)
     - [Royale Api](#royaleapi)
   - [Call Endpoints](t#call-endpoints)
   - [Synchronous Wrapper](#synchronous-wrapper)
3. [License](#license)

## <a name="installation"></a> Installation

|                                       | Logo                                                                                                                                                                              | Stable                                                                                                                                  | Nightly                                                                                                                                                                                                                 |
| ------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| P.E.K.K.A Clash Royale API (official) | <img src="https://raw.githubusercontent.com/Blind-Striker/clash-royale-client-dotnet/master/assets/pekka-clash-royale-api-logo.png" width="150" height="150" title="Github Logo"> | [![NuGet](https://img.shields.io/nuget/v/Pekka.ClashRoyaleApi.Client.svg)](https://www.nuget.org/packages/Pekka.ClashRoyaleApi.Client/) | [![MyGet](https://img.shields.io/myget/pekka-clashroyaleapi-client/vpre/Pekka.ClashRoyaleApi.Client.svg?label=myget)](https://www.myget.org/feed/pekka-clashroyaleapi-client/package/nuget/Pekka.ClashRoyaleApi.Client) |
| P.E.K.K.A Royale API (unofficial)     | <img src="https://raw.githubusercontent.com/Blind-Striker/clash-royale-client-dotnet/master/assets/pekka-royale-api-logo.png" width="150" height="150" title="Github Logo">       | [![NuGet](https://img.shields.io/nuget/v/Pekka.RoyaleApi.Client.svg)](https://www.nuget.org/packages/Pekka.RoyaleApi.Client/)           | [![MyGet](https://img.shields.io/myget/pekka-royaleapi-client/vpre/Pekka.RoyaleApi.Client.svg?label=myget)](https://www.myget.org/feed/pekka-royaleapi-client/package/nuget/Pekka.RoyaleApi.Client)                     |

Following commands can be used to install both Pekka.ClashRoyaleApi.Client and Pekka.RoyaleApi.Client, run the following command in the Package Manager Console

```
Install-Package Pekka.ClashRoyaleApi.Client
Install-Package Pekka.RoyaleApi.Client
```

Or use `dotnet cli`

```
dotnet Pekka.ClashRoyaleApi.Client
dotnet Pekka.RoyaleApi.Client
```

## <a name="usage"></a> Usage

The usage of both Pekka.ClashRoyaleApi.Client and Pekka.RoyaleApi.Client libraries are similar. And both can be used with any DI library, or it can be used standalone.

### <a name="standalone-initialization"></a> Standalone Initialization

If you do not want to use any DI framework, you have to instantiate `ClashRoyaleApiStandalone` or `RoyaleApiStandalone` as follows.

#### <a name="royaleapistandalone"></a> RoyaleApiStandalone Usage

```csharp
ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");
var apiClientContext = RoyaleApiStandalone.Create(apiOptions);
IPlayerClient playerClient = apiClientContext.PlayerClient;
IClanClient clanClient = apiClientContext.ClanClient;
IVersionClient clanClient = apiClientContext.VersionClient;
```

#### <a name="clashroyaleapistandalone"></a> ClashRoyaleApiStandalone Usage

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

### <a name="microsoftextensionsdependencyinjection-initialization"></a> Microsoft.Extensions.DependencyInjection Initialization

First, you need to install `Microsoft.Extensions.DependencyInjection` and `Microsoft.Extensions.Http` NuGet package as follows

```
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet add package Microsoft.Extensions.Http
```

By installing `Microsoft.Extensions.Http` you will be able to use [`HttpClientFactory`](https://www.stevejgordon.co.uk/introduction-to-httpclientfactory-aspnetcore).In the words of the ASP.NET Team it is “an opinionated factory for creating HttpClient instances” and is a new feature comes with the release of ASP.NET Core 2.1.

If you don't want to use `HttpClientFactory`, you must register `HttpClient` yourself with the container.

#### <a name="royaleapi"></a> Royale Api

Register necessary dependencies to `ServiceCollection` as follows

```csharp
ApiOptions apiOptions = new ApiOptions("<your token>", "https://api.royaleapi.com/");

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

var buildServiceProvider = services.BuildServiceProvider();

var playerClient = buildServiceProvider.GetRequiredService<IPlayerClient>();
var clanClient = buildServiceProvider.GetRequiredService<IClanClient>();
var versionClient = buildServiceProvider.GetRequiredService<IVersionClient>();
var constantClient = buildServiceProvider.GetRequiredService<IConstantClient>();
var restApiClient = buildServiceProvider.GetRequiredService<IRestApiClient>();
```

See [sandbox project](https://github.com/Blind-Striker/clash-royale-client-dotnet/blob/master/tests/Pekka.RoyaleApi.Sandbox/Program.cs) for more examples.

### <a name="call-endpoints"></a> Call Endpoints

There are two ways to call an endpoint. The only difference is the return types. The methods that end with ResponseAsync returns `ApiResponse<TModel>` which contains model itself, HTTP status codes, error message and response headers.

```csharp
ApiResponse<Player> playerResponse = await playerClient.GetPlayerResponseAsync(playerTag);

if(playerResponse.Error)
{
  HttpStatusCode statusCode = playerResponse.HttpStatusCode;
  string errorMessage = playerResponse.Message;
  IDictionary<string, string> headers = playerResponse.Headers;
  string urlPath = playerResponse.UrlPath;
    // Handle http error
}

Player player = playerResponse.Model;
```

The methods that end with Async returns model itself without additional HTTP response information. But in the case of HTTP error, you need to handle exceptions.

```csharp
Player player = await playerClient.GetPlayerAsync(playerTag);
```

### <a name="synchronous-wrapper"></a> Synchronous Wrapper

For synchronous calls, Task extension method `RunSync` can be used.

```csharp
var player = playerClient.GetPlayerResponseAsync(playerTag).RunSync();
```

But there is a possibility that this extension method can't cover all cases. See Stackoverflow [article](https://stackoverflow.com/a/25097498/1577827)

## <a name="license"></a> License

Licensed under MIT, see [LICENSE](LICENSE) for the full text.
