using Pekka.Core.Helpers;

using System;

namespace Pekka.Core.Tests.Helpers
{
    public class MockTimeProvider : TimeProvider
    {
        private DateTime _utcNow;

        private MockTimeProvider()
        {
        }

        public static MockTimeProvider Instance { get; } = new MockTimeProvider();

        public override DateTime UtcNow => _utcNow;

        public MockTimeProvider SetUtcNow(DateTime dateTime)
        {
            _utcNow = dateTime;

            return this;
        }
    }
}