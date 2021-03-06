﻿using Moq;
using Moq.Protected;

using Newtonsoft.Json;

using Pekka.Core.Helpers;
using Pekka.Core.Tests.Mock;

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Pekka.Core.Tests.RestApiClientTests
{
    public class GetAsyncTests
    {
        [Fact]
        public async Task GetStringContentAsync_Should_Throw_ArgumentException_If_Path_Is_Null_Or_Empty()
        {
            var restApiClient = new RestApiClient(new HttpClient(new Mock<HttpMessageHandler>(MockBehavior.Strict).Object));

            await Assert.ThrowsAsync<ArgumentNullException>(() => restApiClient.GetAsync<SampleData>(null));
            await Assert.ThrowsAsync<ArgumentException>(() => restApiClient.GetAsync<SampleData>(string.Empty));
        }

        [Fact]
        public async Task GetAsync_Should_Return_DeserializedObject()
        {
            var sampleData = new SampleData() {Owner = "Fatma", SampleCount = 5, CreateDate = TimeProvider.Current.UtcNow};

            string stringContent = JsonConvert.SerializeObject(sampleData);

            var httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            httpMessageHandler.Protected()
                              .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                              .ReturnsAsync(new HttpResponseMessage() {StatusCode = HttpStatusCode.OK, Content = new StringContent(stringContent)})
                              .Verifiable();

            HttpClient httpClient = MockData.GetMockHttpClient(httpMessageHandler);
            var restApiClient = new RestApiClient(httpClient);

            SampleData statisticResult = await restApiClient.GetAsync<SampleData>("statistic");

            httpMessageHandler.Protected()
                              .Verify("SendAsync", Times.Once(),
                                      ItExpr.Is<HttpRequestMessage>(message => message.Method == HttpMethod.Get && message.RequestUri.ToString().Contains("statistic")),
                                      ItExpr.IsAny<CancellationToken>());

            Assert.NotNull(statisticResult);
            Assert.Equal(sampleData.SampleCount, statisticResult.SampleCount);
            Assert.Equal(sampleData.CreateDate, statisticResult.CreateDate);
            Assert.Equal(sampleData.Owner, statisticResult.Owner);
        }
    }
}