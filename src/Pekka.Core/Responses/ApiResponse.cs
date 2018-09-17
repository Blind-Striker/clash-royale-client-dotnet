using System.Net;

namespace Pekka.Core.Responses
{
    public class ApiResponse<TModel> : ApiResponse where TModel : class, new()
    {
        public TModel Model { get; set; }
    }

    public class ApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public bool Error { get; set; }
    }
}
