using Newtonsoft.Json;
using Pekka.Core.Responses;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pekka.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<IApiResponse<TModel>> ConvertToApiResponse<TModel>(this HttpResponseMessage httpResponseMessage, string urlPath = null, JsonSerializerSettings jsonSerializerSettings = null)
            where TModel : class
        {
            var stringContent = await httpResponseMessage.Content.ReadAsStringAsync();

            var apiResponse = new ApiResponse<TModel>
            {
                HttpStatusCode = httpResponseMessage.StatusCode,
                Headers = httpResponseMessage.Headers.ToDictionary(pair => pair.Key, pair => pair.Value.First()),
                UrlPath = urlPath
            };

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                var converted = jsonSerializerSettings == null
                    ? stringContent.TryDeserializeObject(out ErrorResponse errorResponse)
                    : stringContent.TryDeserializeObject(out errorResponse, jsonSerializerSettings);
                apiResponse.Error = true;
                apiResponse.Message = converted ? $"{errorResponse.Error} - {errorResponse.ErrorDescription}" : stringContent;

                return apiResponse;
            }

            TModel model = jsonSerializerSettings == null
                ? JsonConvert.DeserializeObject<TModel>(stringContent)
                : JsonConvert.DeserializeObject<TModel>(stringContent, jsonSerializerSettings);
            apiResponse.Model = model;

            return apiResponse;
        }
    }
}