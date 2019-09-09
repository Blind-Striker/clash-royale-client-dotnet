namespace Pekka.Core
{
    public class ApiOptions
    {
        public ApiOptions(string bearerToken, string baseUrl)
        {
            BearerToken = bearerToken;
            BaseUrl = baseUrl;
        }

        public string BearerToken { get; }

        public string BaseUrl { get; }
    }
}
