using System.Collections.Generic;
using System.Net;

namespace Pekka.Core.Responses
{
    public class ApiResponse<TModel> : ApiResponse, IApiResponse<TModel> where TModel : class
    {
        public TModel Model { get; set; }
    }

    public interface IApiResponse<out TModel> : IApiResponse where TModel : class
    {
        TModel Model { get; }
    }

    public interface IApiResponse
    {
        HttpStatusCode HttpStatusCode { get; }

        IDictionary<string, string> Headers { get; }

        string UrlPath { get; }

        string Message { get; }

        bool Error { get; }
    }

    public class ApiResponse : IApiResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public IDictionary<string, string> Headers { get; set; }

        public string UrlPath { get; set; }

        public string Message { get; set; }

        public bool Error { get; set; }
    }
}