using Moq;
using Moq.Protected;
using Pekka.Core.Tests.Helpers;
using Pekka.Core.Tests.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pekka.Core.Tests.RestApiClientTests
{
    public class CallAsyncTests
    {
        [Fact]
        public async Task CallAsync_Should_Throw_ArgumentException_If_Path_Is_Null_Or_Empty()
        {
            var restApiClient = new RestApiClient(new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object), MockData.MockApiOptions);

            await Assert.ThrowsAsync<ArgumentNullException>(() => restApiClient.CallAsync(HttpMethod.Get, null));
            await Assert.ThrowsAsync<ArgumentException>(() => restApiClient.CallAsync(HttpMethod.Get, string.Empty));
        }

        [Theory]
        [InlineData("GET", "pull_request", null, null)]
        [InlineData("POST", "commits", null, null)]
        [InlineData("PUT", "commits", null, null)]
        [InlineData("DELETE", "commits/comment", null, null)]
        [InlineData("GET", "pull_request", "time_frame=all;start_date=2018-01-01;end_date=2018-01-02", "header1=header1Value;header2=header2Value")]
        [InlineData("POST", "pull_request", "time_frame=all;end_date=2018-01-02", "header1=header1Value")]
        [InlineData("PUT", "pull_request", "start_date=2018-01-01;end_date=2018-01-02", "header1=header1Value;header2=header2Value")]
        [InlineData("DELETE", "user", "time_frame=all;start_date=2018-01-01", "header1=header1Value")]
        public async Task CallAsync_Should_Call_HttpClient_SendAsync_With_HttpRequestMessage_By_Given_Parameters(string httpMethodStr, string path, string queryParams, string headerParams)
        {
            var httpMethod = new HttpMethod(httpMethodStr);
            IList<KeyValuePair<string, string>> queryStingParameters = queryParams.ToQueryStingParameters();
            IDictionary<string, string> headerParameters = headerParams.ToHeaderParameters();

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            httpMessageHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage()
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("[{'id':1,'value':'1'}]"),
                })
                .Verifiable();

            var httpClient = new HttpClient(httpMessageHandler.Object);
            var restApiClient = new RestApiClient(httpClient, MockData.MockApiOptions);

            await restApiClient.CallAsync(httpMethod, path, queryStingParameters, headerParameters);

            httpMessageHandler.Protected()
                              .Verify("SendAsync", Times.Once(),
                                      ItExpr.Is<HttpRequestMessage>(message => IsValidHttpRequestMessage(message, httpMethod, path, queryStingParameters, headerParameters)), ItExpr.IsAny<CancellationToken>());
        }

        private static bool IsValidHttpRequestMessage(HttpRequestMessage httpRequestMessage,
                                                      HttpMethod httpMethod,
                                                      string path,
                                                      IList<KeyValuePair<string, string>> queryStingParameters,
                                                      IDictionary<string, string> headerParameters)
        {
            if (httpRequestMessage.Method != httpMethod)
            {
                return false;
            }

            string requestUriAbsoluteUri = httpRequestMessage.RequestUri.ToString();

            if (!requestUriAbsoluteUri.Contains(path))
            {
                return false;
            }

            if (queryStingParameters != null)
            {
                if (queryStingParameters.Any(valuePair => !requestUriAbsoluteUri.Contains($"{valuePair.Key}={valuePair.Value}")))
                {
                    return false;
                }
            }

            return headerParameters == null || headerParameters.All(valuePair => httpRequestMessage.Headers.GetValues(valuePair.Key).Contains(valuePair.Value));
        }
    }
}