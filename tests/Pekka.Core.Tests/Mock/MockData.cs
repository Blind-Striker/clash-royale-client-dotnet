using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;

namespace Pekka.Core.Tests.Mock
{
    public static class MockData
    {
        public const string BaseUrl = "https://bitbucket.org";
        public const string AccessTokenPath = "/site/oauth2/access_token";

        public static readonly ApiOptions MockApiOptions = new ApiOptions("asdsadsadsa", BaseUrl);
        public static readonly ApiOptions EmptyApiOptions = new ApiOptions(string.Empty, string.Empty);

        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() }
        };
    }

    public class PullRequest
    {
        public string Owner { get; set; }

        public int CommentCount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}