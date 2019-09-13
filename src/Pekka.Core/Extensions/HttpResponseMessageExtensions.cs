using Newtonsoft.Json;

using Pekka.Core.Responses;

using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pekka.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<IApiResponse<TModel>> ConvertToApiResponse<TModel>(
            this HttpResponseMessage httpResponseMessage, string urlPath = null)
            where TModel : class
        {
            string stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<TModel>
            {
                HttpStatusCode = httpResponseMessage.StatusCode,
                Headers = httpResponseMessage.Headers.ToDictionary(pair => pair.Key, pair => pair.Value.First()),
                UrlPath = urlPath
            };

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                bool converted = stringContent.TryDeserializeObject(out ErrorResponse errorResponse);
                apiResponse.Error = true;
                apiResponse.Message = converted ? $"{errorResponse.Message}" : stringContent;

                return apiResponse;
            }

            var model = JsonConvert.DeserializeObject<TModel>(stringContent);

            apiResponse.Model = model;

            return apiResponse;
        }
    }
}