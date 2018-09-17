using System.Collections.Generic;

namespace Pekka.RoyaleApi.Client.Helpers
{
    public static class StringExtensions
    {
        public static string JoinToString(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
