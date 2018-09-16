using System.Collections.Generic;

namespace RoyaleApi.Client.Helpers
{
    internal static class StringExtensions
    {
        public static string JoinToString(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
