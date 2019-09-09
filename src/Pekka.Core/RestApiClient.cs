using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pekka.Core
{
    public class RestApiClient : IRestApiClient
    {
        protected readonly HttpClient HttpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RestApiClient(HttpClient httpClient, ApiOptions apiOptions)
        {
            HttpClient = httpClient;
            HttpClient.BaseAddress = new Uri(apiOptions.BaseUrl);

            HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiOptions.BearerToken);

            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy()
                }
            };
        }

        public async Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpResponseMessage httpResponseMessage =
                await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                return await httpResponseMessage.ConvertToApiResponse<TModel>(path, _jsonSerializerSettings);
            }
        }

        public async Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(HttpRequestMessage httpRequestMessage)
            where TModel : class
        {
            Ensure.ArgumentNotNull(httpRequestMessage, nameof(httpRequestMessage));

            using (HttpResponseMessage httpResponseMessage = await CallAsync(httpRequestMessage))
            {
                return await httpResponseMessage.ConvertToApiResponse<TModel>(httpRequestMessage.RequestUri.ToString(),
                    _jsonSerializerSettings);
            }
        }

        public async Task<TModel> GetAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            string stringContent = await GetStringContentAsync(path, queryParams, headerParams);

            return JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);
        }

        public async Task<string> GetStringContentAsync(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpResponseMessage httpResponseMessage =
                await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return stringContent;
            }
        }

        public ConfiguredTaskAwaitable<HttpResponseMessage> CallAsync(HttpMethod httpMethod, string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, path)
                .AddQueryParameters(queryParams)
                .AddHeaders(headerParams))
            {
                return CallAsync(httpRequestMessage);
            }
        }

        public ConfiguredTaskAwaitable<HttpResponseMessage> CallAsync(HttpRequestMessage httpRequestMessage)
        {
            Ensure.ArgumentNotNull(httpRequestMessage, nameof(httpRequestMessage));

            return HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
        }
    }
}