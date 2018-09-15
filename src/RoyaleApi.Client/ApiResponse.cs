using System.Net;

namespace RoyaleApi.Client
{
    public class ApiResponse<TModel> : ApiResponse where TModel : class, new()
    {
        public TModel Model { get; set; }
    }

    public class ApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Content { get; set; }
    }
}
