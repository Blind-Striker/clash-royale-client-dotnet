using System;
using System.Threading;

namespace Pekka.Core.Tests.HelperTests.AsyncLockTests.Fakes
{
    // This class taken from another github repository
    // NeoSmart Technologies, AsyncLock: An async/await-friendly lock, (2019), GitHub repository, https://github.com/neosmart/AsyncLock
    // Commit https://github.com/neosmart/AsyncLock/tree/491ceb9a7bb391d0691ebc569e550e86885dec91
    // License https://github.com/neosmart/AsyncLock/blob/master/LICENSE

    /// <summary>
    /// A fake resource that will invoke a callback if more than n instances are simultaneously accessed
    /// </summary>
    internal class LimitedResource
    {
        private readonly Action _failureCallback;
        private readonly int _max = 1;
        private int _unsafe = 0;

        public LimitedResource(Action onFailure, int maxSimultaneous = 1)
        {
            _max = maxSimultaneous;
            _failureCallback = onFailure;
        }

        public void BeginSomethingDangerous()
        {
            if (Interlocked.Increment(ref _unsafe) > _max)
            {
                _failureCallback();
            }
        }

        public void EndSomethingDangerous()
        {
            Interlocked.Decrement(ref _unsafe);
        }
    }
}