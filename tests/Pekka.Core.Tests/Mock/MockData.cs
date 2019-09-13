using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using System;
using System.Net.Http;
using System.Net.Http.Headers;

using Moq;

namespace Pekka.Core.Tests.Mock
{
    public static class MockData
    {
        public const string BaseUrl = "https://bitbucket.org";
        public const string AccessTokenPath = "/site/oauth2/access_token";

        public static readonly ApiOptions MockApiOptions = new ApiOptions("asdsadsadsa", BaseUrl);
        public static readonly ApiOptions EmptyApiOptions = new ApiOptions(string.Empty, string.Empty);

        public static HttpClient GetMockHttpClient(Mock<HttpMessageHandler> httpMessageHandler)
        {
            var httpClient = new HttpClient(httpMessageHandler.Object) {BaseAddress = new Uri(MockData.BaseUrl)};
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", MockData.MockApiOptions.BearerToken);

            return httpClient;
        }
    }

    public class SampleData
    {
        public string Owner { get; set; }

        public int SampleCount { get; set; }

        public DateTime CreateDate { get; set; }
    }
}