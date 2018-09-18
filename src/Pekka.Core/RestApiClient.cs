using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pekka.Core.Contracts;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

namespace Pekka.Core
{
    public class RestApiClient : IRestApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RestApiClient(HttpClient httpClient, ApiOptions apiOptions)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiOptions.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiOptions.BearerToken);

            _jsonSerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };
        }

        public async Task<ApiResponse<TModel>> GetApiResponseAsync<TModel>(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpResponseMessage httpResponseMessage = await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

                var apiResponse = new ApiResponse<TModel>()
                {
                    HttpStatusCode = httpResponseMessage.StatusCode,
                    Headers = httpResponseMessage.Headers.ToDictionary(pair => pair.Key, pair => pair.Value.First()),
                    UrlPath = path
                };
                
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringContent, _jsonSerializerSettings);
                    apiResponse.Error = true;
                    apiResponse.Message = errorResponse.Message;

                    return apiResponse;
                }

                var model = JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);
                apiResponse.Model = model;

                return apiResponse;
            }
        }

        public async Task<ApiResponse> GetApiResponseAsync(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpResponseMessage httpResponseMessage = await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return new ApiResponse()
                {
                    HttpStatusCode = httpResponseMessage.StatusCode,
                    Headers = httpResponseMessage.Headers.ToDictionary(pair => pair.Key, pair => pair.Value.First()),
                    UrlPath = path,
                    Message = !httpResponseMessage.IsSuccessStatusCode
                        ? JsonConvert.DeserializeObject<ErrorResponse>(stringContent, _jsonSerializerSettings)?.Message
                        : null,
                    Error = !httpResponseMessage.IsSuccessStatusCode
                };
            }
        }

        public async Task<TModel> GetAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null) where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            string stringContent = await GetStringContentAsync(path, queryParams, headerParams);

            return JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);
        }

        public async Task<string> GetStringContentAsync(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (var httpResponseMessage = await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                string stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

                return stringContent;
            }
        }

        public async Task<HttpResponseMessage> CallAsync(HttpMethod httpMethod, string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (var httpRequestMessage = PrepaRequestMessage(path, httpMethod, queryParams, headerParams))
            {
                HttpResponseMessage httpResponse = await _httpClient.SendAsync(httpRequestMessage);

                return httpResponse;
            }
        }

        public HttpRequestMessage PrepaRequestMessage(
            string path, 
            HttpMethod httpMethod,
            IList<KeyValuePair<string, string>> queryParams = null, 
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            var uriBuilder = new UriBuilder(path) {Port = -1};

            if (queryParams != null && queryParams.Any())
            {
                var query = HttpUtility.ParseQueryString(string.Empty);

                foreach (var queryParam in queryParams)
                {
                    query[queryParam.Key] = queryParam.Value;
                }

                uriBuilder.Query = query.ToString();
            }

            Uri uri = uriBuilder.Uri;

            var requestMessage = new HttpRequestMessage(httpMethod, uri);

            if (headerParams == null || !headerParams.Any())
            {
                return requestMessage;
            }

            foreach (var headerParam in headerParams)
            {
                requestMessage.Headers.Add(headerParam.Key, headerParam.Value);
            }

            return requestMessage;
        }
    }
}
