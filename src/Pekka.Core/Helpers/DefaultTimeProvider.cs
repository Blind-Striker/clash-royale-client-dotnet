using System;
using System.Collections.Generic;
using System.Text;

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
