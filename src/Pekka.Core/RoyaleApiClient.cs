using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Pekka.RoyaleApi.Client.Contracts;
using Pekka.RoyaleApi.Client.Helpers;
using Pekka.RoyaleApi.Client.Responses;

namespace Pekka.RoyaleApi.Client.Clients
{
    public class RoyaleApiClient : IRoyaleApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RoyaleApiClient(HttpClient httpClient, ApiOptions apiOptions)
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

        public async Task<ApiResponse<TModel>> GetApiResponseAsync<TModel>(string url) where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(url, nameof(url));

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            string stringContent = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                var errorResponse = JsonConvert.DeserializeObject<ErrorResponse>(stringContent, _jsonSerializerSettings);

                return new ApiResponse<TModel>()
                {
                    HttpStatusCode = httpResponse.StatusCode,
                    Message = errorResponse.Message,
                    Error = true
                };
            }

            var model = JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);

            return new ApiResponse<TModel>()
            {
                HttpStatusCode = httpResponse.StatusCode,
                Model = model
            };
        }

        public async Task<ApiResponse> GetStringContentAsync(string url)
        {
            Ensure.ArgumentNotNullOrEmptyString(url, nameof(url));

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            string stringContent = await httpResponse.Content.ReadAsStringAsync();

            return new ApiResponse() {Message = stringContent, HttpStatusCode = httpResponse.StatusCode};
        }

        public async Task<TModel> GetAsync<TModel>(string url) where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(url, nameof(url));

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            string stringContent = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);
        }
    }
}
