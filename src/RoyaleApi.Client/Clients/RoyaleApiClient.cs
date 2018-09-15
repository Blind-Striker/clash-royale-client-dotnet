using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RoyaleApi.Client.Contracts;
using RoyaleApi.Client.Helpers;

namespace RoyaleApi.Client.Clients
{
    public class RoyaleApiClient : IRoyaleApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ApiOptions _apiOptions;
        private readonly JsonSerializerSettings _jsonSerializerSettings;

        public RoyaleApiClient(HttpClient httpClient, ApiOptions apiOptions)
        {
            _httpClient = httpClient;
            _apiOptions = apiOptions;

            _httpClient.BaseAddress = new Uri(_apiOptions.BaseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiOptions.BearerToken);

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
                return new ApiResponse<TModel>()
                {
                    HttpStatusCode = httpResponse.StatusCode,
                    Content = stringContent,
                    Model = null
                };
            }

            var model = JsonConvert.DeserializeObject<TModel>(stringContent, _jsonSerializerSettings);

            return new ApiResponse<TModel>()
            {
                HttpStatusCode = httpResponse.StatusCode,
                Model = model,
                Content = null
            };
        }

        public async Task<ApiResponse> GetStringContentAsync(string url)
        {
            Ensure.ArgumentNotNullOrEmptyString(url, nameof(url));

            HttpResponseMessage httpResponse = await _httpClient.GetAsync(url);
            string stringContent = await httpResponse.Content.ReadAsStringAsync();

            return new ApiResponse() {Content = stringContent, HttpStatusCode = httpResponse.StatusCode};
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
