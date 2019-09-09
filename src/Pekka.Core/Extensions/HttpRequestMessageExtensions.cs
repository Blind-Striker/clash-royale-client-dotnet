using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using Pekka.Core.Helpers;

namespace Pekka.Core.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        public static HttpRequestMessage AddQueryParameter(this HttpRequestMessage requestMessage, string key, string value)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));
            Ensure.ArgumentNotNullOrEmptyString(key, nameof(key));
            Ensure.ArgumentNotNullOrEmptyString(value, nameof(value));

            var requestUriQuery = requestMessage.RequestUri.Query;

            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(string.IsNullOrEmpty(requestUriQuery) ? string.Empty : requestUriQuery);
            queryStringCollection[key] = value;

            requestMessage.RequestUri = string.IsNullOrEmpty(requestUriQuery)
                ? new Uri($"{requestMessage.RequestUri}?{queryStringCollection}")
                : new Uri(requestMessage.RequestUri.ToString().Replace(requestUriQuery, $"?{queryStringCollection}"));
            return requestMessage;
        }

        public static HttpRequestMessage AddQueryParameters(this HttpRequestMessage requestMessage, IList<KeyValuePair<string, string>> queryParams)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));

            if (queryParams == null || queryParams.Count == 0)
            {
                return requestMessage;
            }

            string url = requestMessage.RequestUri.ToString();

            int idx = url.IndexOf('?');
            string query = idx >= 0 ? url.Substring(idx) : string.Empty;

            NameValueCollection queryStringCollection = HttpUtility.ParseQueryString(query);

            foreach (KeyValuePair<string, string> queryParam in queryParams)
            {
                queryStringCollection[queryParam.Key] = queryParam.Value;
            }

            string queryStrings = queryStringCollection.AllKeys.Select(key => $"{key}={queryStringCollection[key]}").JoinToString("&");

            UriKind uriKind = GetUriKind(url);

            requestMessage.RequestUri = string.IsNullOrEmpty(query)
                ? new Uri($"{requestMessage.RequestUri}?{queryStrings}", uriKind)
                : new Uri(requestMessage.RequestUri.ToString().Replace(query, $"?{queryStrings}"), uriKind);
            return requestMessage;
        }

        public static HttpRequestMessage AddHeader(this HttpRequestMessage requestMessage, string key, string value)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));
            Ensure.ArgumentNotNullOrEmptyString(key, nameof(key));
            Ensure.ArgumentNotNullOrEmptyString(value, nameof(value));

            requestMessage.Headers.Add(key, value);

            return requestMessage;
        }

        public static HttpRequestMessage AddHeaders(this HttpRequestMessage requestMessage, IDictionary<string, string> headerParams)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));

            if (headerParams == null || headerParams.Count == 0)
            {
                return requestMessage;
            }

            foreach (KeyValuePair<string, string> headerParam in headerParams)
            {
                requestMessage.Headers.Add(headerParam.Key, headerParam.Value);
            }

            return requestMessage;
        }

        public static HttpRequestMessage AddOAuth2AuthorizationRequestHeader(
            this HttpRequestMessage requestMessage,
            string key, string secret)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));
            Ensure.ArgumentNotNullOrEmptyString(key, nameof(key));
            Ensure.ArgumentNotNullOrEmptyString(secret, nameof(secret));

            var credential = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{key}:{secret}"));

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Basic", credential);

            return requestMessage;
        }

        public static HttpRequestMessage AddFormUrlEncodedContent(this HttpRequestMessage requestMessage, IList<KeyValuePair<string, string>> formData)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));
            Ensure.ArgumentNotNullOrEmptyEnumerable(formData, nameof(formData));

            requestMessage.Content = new FormUrlEncodedContent(formData);

            return requestMessage;
        }

        public static HttpRequestMessage AddJsonContent(this HttpRequestMessage requestMessage, object data, JsonSerializerSettings jsonSerializerSettings = null)
        {
            Ensure.ArgumentNotNull(requestMessage, nameof(requestMessage));
            Ensure.ArgumentNotNull(data, nameof(data));

            var stringContent = jsonSerializerSettings == null
                ? JsonConvert.SerializeObject(data)
                : JsonConvert.SerializeObject(data, jsonSerializerSettings);

            var content = new StringContent(stringContent, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            requestMessage.Content = content;

            return requestMessage;
        }

        private static UriKind GetUriKind(string url) => Uri.TryCreate(url, UriKind.Absolute, out Uri _) ? UriKind.Absolute : UriKind.Relative;
    }
}
