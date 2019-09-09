using System;

namespace Pekka.Core.Helpers
{
    public class DefaultTimeProvider : TimeProvider
    {
        private DefaultTimeProvider()
        {
        }

        public override DateTime UtcNow => DateTime.UtcNow;

        public static DefaultTimeProvider Instance { get; } = new DefaultTimeProvider();
    }
}