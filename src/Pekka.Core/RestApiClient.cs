using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using Pekka.Core.Contracts;
using Pekka.Core.Extensions;
using Pekka.Core.Helpers;
using Pekka.Core.Responses;

using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pekka.Core
{
    public class RestApiClient : IRestApiClient
    {
        protected readonly HttpClient HttpClient;

        public RestApiClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public async Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null, NamingStrategy namingStrategy = null)
            where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpResponseMessage httpResponseMessage =
                await CallAsync(HttpMethod.Get, path, queryParams, headerParams))
            {
                return await httpResponseMessage.ConvertToApiResponse<TModel>(path);
            }
        }

        public async Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(HttpRequestMessage httpRequestMessage,
            NamingStrategy namingStrategy = null)
            where TModel : class
        {
            Ensure.ArgumentNotNull(httpRequestMessage, nameof(httpRequestMessage));

            using (HttpResponseMessage httpResponseMessage = await CallAsync(httpRequestMessage))
            {
                return await httpResponseMessage.ConvertToApiResponse<TModel>(httpRequestMessage.RequestUri.ToString());
            }
        }

        public async Task<TModel> GetAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null, NamingStrategy namingStrategy = null)
            where TModel : class, new()
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            string stringContent = await GetStringContentAsync(path, queryParams, headerParams);

            return JsonConvert.DeserializeObject<TModel>(stringContent);
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

        public async Task<HttpResponseMessage> CallAsync(HttpMethod httpMethod, string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
        {
            Ensure.ArgumentNotNullOrEmptyString(path, nameof(path));

            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, path)
                .AddQueryParameters(queryParams)
                .AddHeaders(headerParams))
            {
                return await CallAsync(httpRequestMessage);
            }
        }

        public async Task<HttpResponseMessage> CallAsync(HttpRequestMessage httpRequestMessage)
        {
            Ensure.ArgumentNotNull(httpRequestMessage, nameof(httpRequestMessage));

            return await HttpClient.SendAsync(httpRequestMessage).ConfigureAwait(false);
        }
    }
}