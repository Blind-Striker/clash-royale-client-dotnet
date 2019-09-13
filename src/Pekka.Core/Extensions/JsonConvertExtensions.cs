using Newtonsoft.Json;

namespace Pekka.Core.Extensions
{
    public static class JsonConvertExtensions
    {
        public static bool TryDeserializeObject<T>(this string value, out T model,
            JsonSerializerSettings jsonSerializerSettings = null)
        {
            model = default(T);

            try
            {
                model = JsonConvert.DeserializeObject<T>(value, jsonSerializerSettings);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}