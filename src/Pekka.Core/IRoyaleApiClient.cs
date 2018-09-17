using System.Threading.Tasks;
using Pekka.RoyaleApi.Client.Responses;

namespace Pekka.RoyaleApi.Client.Contracts
{
    public interface IRoyaleApiClient
    {
        Task<ApiResponse<TModel>> GetApiResponseAsync<TModel>(string url) where TModel : class, new();
        Task<ApiResponse> GetStringContentAsync(string url);
        Task<TModel> GetAsync<TModel>(string url) where TModel : class, new();
    }
}