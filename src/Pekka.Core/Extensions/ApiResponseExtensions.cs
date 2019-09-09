using Pekka.Core.Exceptions;
using Pekka.Core.Responses;

namespace Pekka.Core.Extensions
{
    public static class ApiResponseExtensions
    {
        public static UnsuccessfulResponseException GetException(this ApiResponse apiResponse)
        {
            return new UnsuccessfulResponseException(apiResponse.Message, apiResponse.UrlPath, apiResponse.HttpStatusCode);
        }

        public static UnsuccessfulResponseException ThrowException(this ApiResponse apiResponse)
        {
            throw apiResponse.GetException();
        }

        public static TModel GetModel<TModel>(this ApiResponse<TModel> apiResponse) where TModel : class, new()
        {
            if (apiResponse.Error)
            {
                apiResponse.ThrowException();
            }

            return apiResponse.Model;
        }
    }
}
