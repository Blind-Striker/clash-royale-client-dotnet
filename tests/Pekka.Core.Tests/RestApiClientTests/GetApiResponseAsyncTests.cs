﻿using Moq;
using Moq.Protected;

using Newtonsoft.Json;

using Pekka.Core.Helpers;
using Pekka.Core.Responses;
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
    public class GetApiResponseAsyncTests
    {
        [Fact]
        public async Task GetApiResponseAsync_Should_Throw_ArgumentException_If_Path_Is_Null_Or_Empty()
        {
            var restApiClient = new RestApiClient(new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object));

            await Assert.ThrowsAsync<ArgumentNullException>(() => restApiClient.GetApiResponseAsync<SampleData>(null, null));

            await Assert.ThrowsAsync<ArgumentException>(() => restApiClient.GetApiResponseAsync<SampleData>(string.Empty));
        }

        [Theory, InlineData(HttpStatusCode.OK, "header1=header1Value;header2=header2Value", "pull_request"),
         InlineData(HttpStatusCode.Accepted, "header3=header3Value;header4=header4Value", "commits"),
         InlineData(HttpStatusCode.InternalServerError, "header3=header3Value;header4=header4Value", "commits/comment"),
         InlineData(HttpStatusCode.Unauthorized, "header3=header3Value;header4=header4Value", "pull_request")]
        public async Task GetApiResponseAsync_Should_Return_ApiResponse_With_StatusCode_And_Headers_And_UrlPath_Regardless_Of_StatusCode_Success_Or_Not(
            HttpStatusCode httpStatusCode, string headerParams, string path)
        {
            var podcast = new SampleData() {Owner = "Yiğit", SampleCount = 5, CreateDate = TimeProvider.Current.UtcNow};

            IDictionary<string, string> headerParameters = headerParams.ToHeaderParameters();

            string stringContent = JsonConvert.SerializeObject(podcast);

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            httpMessageHandler.Protected()
                              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                              .ReturnsAsync(new HttpResponseMessage() {StatusCode = httpStatusCode, Content = new StringContent(stringContent)})
                              .Verifiable();

            HttpClient httpClient = MockData.GetMockHttpClient(httpMessageHandler);
            var restApiClient = new RestApiClient(httpClient);

            IApiResponse<SampleData> apiResponse = await restApiClient.GetApiResponseAsync<SampleData>(path, null, headerParameters);

            httpMessageHandler.Protected()
                              .Verify("SendAsync", Times.Once(),
                                      ItExpr.Is<HttpRequestMessage>(message => message.Method == HttpMethod.Get && message.RequestUri.ToString().Contains(path)),
                                      ItExpr.IsAny<CancellationToken>());

            Assert.Equal(httpStatusCode, apiResponse.HttpStatusCode);

            Assert.Contains(headerParameters, pair => apiResponse.Headers.All(valuePair => valuePair.Key == pair.Key && valuePair.Value == pair.Value));

            Assert.Equal(path, apiResponse.UrlPath);
        }

        [Fact]
        public async Task GetApiResponseAsync_Should_Return_ApiResponse_With_Success_And_DeserializedObject_If_HttpResponseMessage_IsSuccessStatusCode_True()
        {
            var podcast = new SampleData() {Owner = "Fatma", SampleCount = 5, CreateDate = TimeProvider.Current.UtcNow};

            string stringContent = JsonConvert.SerializeObject(podcast);

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            httpMessageHandler.Protected()
                              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                              .ReturnsAsync(new HttpResponseMessage() {StatusCode = HttpStatusCode.OK, Content = new StringContent(stringContent)})
                              .Verifiable();

            HttpClient httpClient = MockData.GetMockHttpClient(httpMessageHandler);
            var restApiClient = new RestApiClient(httpClient);

            IApiResponse<SampleData> apiResponse = await restApiClient.GetApiResponseAsync<SampleData>("pull_request");

            httpMessageHandler.Protected()
                              .Verify("SendAsync", Times.Once(),
                                      ItExpr.Is<HttpRequestMessage>(
                                          message => message.Method == HttpMethod.Get && message.RequestUri.ToString().Contains("pull_request")),
                                      ItExpr.IsAny<CancellationToken>());

            Assert.Equal(HttpStatusCode.OK, apiResponse.HttpStatusCode);
            Assert.False(apiResponse.Error);
            Assert.NotNull(apiResponse.Model);
            Assert.Null(apiResponse.Message);
            Assert.Equal(podcast.Owner, apiResponse.Model.Owner);
            Assert.Equal(podcast.SampleCount, apiResponse.Model.SampleCount);
            Assert.Equal(podcast.CreateDate, apiResponse.Model.CreateDate);
        }

        [Fact]
        public async Task GetApiResponseAsync_Should_Return_ApiResponse_With_Error_True_And_With_Error_Message_If_HttpResponseMessage_IsSuccessStatusCode_True()
        {
            var errorResponse = new {Error = true, Message = "You need do something", Status = 500};
            string stringContent = JsonConvert.SerializeObject(errorResponse);

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            httpMessageHandler.Protected()
                              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                              .ReturnsAsync(new HttpResponseMessage() {StatusCode = HttpStatusCode.InternalServerError, Content = new StringContent(stringContent)})
                              .Verifiable();

            HttpClient httpClient = MockData.GetMockHttpClient(httpMessageHandler);
            var restApiClient = new RestApiClient(httpClient);

            IApiResponse<SampleData> apiResponse = await restApiClient.GetApiResponseAsync<SampleData>("pull_request");

            httpMessageHandler.Protected()
                              .Verify("SendAsync", Times.Once(),
                                      ItExpr.Is<HttpRequestMessage>(
                                          message => message.Method == HttpMethod.Get && message.RequestUri.ToString().Contains("pull_request")),
                                      ItExpr.IsAny<CancellationToken>());

            Assert.Equal(HttpStatusCode.InternalServerError, apiResponse.HttpStatusCode);
            Assert.True(apiResponse.Error);
            Assert.Null(apiResponse.Model);
            Assert.Contains(stringContent, apiResponse.Message);
        }
    }
}