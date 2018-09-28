using System.Collections.Generic;

namespace Pekka.Core.Helpers
{
    public static class StringExtensions
    {
        public static string JoinToString(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }

        public static string ToCamelCase(this string value)
        {
            Ensure.ArgumentNotNullOrEmptyString(value, nameof(value));

            return $"{char.ToLowerInvariant(value[0])}{value.Substring(1)}".Replace("_", string.Empty);
        }
    }
}
