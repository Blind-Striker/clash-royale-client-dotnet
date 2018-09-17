using System.Collections.Generic;

namespace Pekka.Core.Helpers
{
    public static class StringExtensions
    {
        public static string JoinToString(this IEnumerable<string> enumerable, string separator)
        {
            return string.Join(separator, enumerable);
        }
    }
}
