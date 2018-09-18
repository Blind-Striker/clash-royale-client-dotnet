using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Pekka.Core.Responses;

namespace Pekka.Core.Contracts
{
    public interface IRestApiClient
    {
        Task<ApiResponse<TModel>> GetApiResponseAsync<TModel>(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null)
            where TModel : class, new();

        Task<ApiResponse> GetApiResponseAsync(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null);

        Task<TModel> GetAsync<TModel>(string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null) where TModel : class, new();

        Task<string> GetStringContentAsync(
            string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null);

        Task<HttpResponseMessage> CallAsync(HttpMethod httpMethod, string path,
            IList<KeyValuePair<string, string>> queryParams = null,
            IDictionary<string, string> headerParams = null);

        HttpRequestMessage PrepaRequestMessage(
            string path, 
            HttpMethod httpMethod,
            IList<KeyValuePair<string, string>> queryParams = null, 
            IDictionary<string, string> headerParams = null);
    }
}