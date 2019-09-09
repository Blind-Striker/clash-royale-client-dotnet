using Pekka.Core.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Pekka.Core.Contracts
{
    public interface IRestApiClient
    {
        Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new();

        Task<IApiResponse<TModel>> GetApiResponseAsync<TModel>(HttpRequestMessage httpRequestMessage)
            where TModel : class;

        Task<TModel> GetAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new();

        Task<string> GetStringContentAsync(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null);

        ConfiguredTaskAwaitable<HttpResponseMessage> CallAsync(HttpMethod httpMethod, string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null);

        ConfiguredTaskAwaitable<HttpResponseMessage> CallAsync(HttpRequestMessage httpRequestMessage);
    }
}