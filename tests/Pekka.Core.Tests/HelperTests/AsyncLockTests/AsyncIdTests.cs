using Pekka.Core.Helpers;

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Pekka.Core.Tests.HelperTests.AsyncLockTests
{
    // This class taken from another github repository
    // NeoSmart Technologies, AsyncLock: An async/await-friendly lock, (2019), GitHub repository, https://github.com/neosmart/AsyncLock
    // Commit https://github.com/neosmart/AsyncLock/tree/491ceb9a7bb391d0691ebc569e550e86885dec91
    // License https://github.com/neosmart/AsyncLock/blob/master/LICENSE

    public class AsyncIdTests
    {
        [Fact]
        public void TaskIdUniqueness()
        {
            var testCount = 100;
            var countdown = new CountdownEvent(testCount);
            var failure = new ManualResetEventSlim(false);
            var threadIds = new SortedSet<long>();
            var abort = new SemaphoreSlim(0, 1);

            for (var i = 0; i < testCount; ++i)
            {
                Task.Run(async () =>
                {
                    lock (threadIds)
                    {
                        if (!threadIds.Add(AsyncLock.ThreadId))
                        {
                            failure.Set();
                        }
                    }

                    countdown.Signal();
                    await abort.WaitAsync();
                });
            }

            if (WaitHandle.WaitAny(new[] {countdown.WaitHandle, failure.WaitHandle}) == 1)
            {
                Assert.True(false, "A duplicate thread id was found!");
            }

            abort.Release();
        }

        [Fact]
        public void ThreadIdUniqueness()
        {
            var testCount = 100;
            var countdown = new CountdownEvent(testCount);
            var failure = new ManualResetEventSlim(false);
            var threadIds = new SortedSet<long>();
            var abort = new SemaphoreSlim(0, 1);

            for (var i = 0; i < testCount; ++i)
            {
                Task.Run(async () =>
                {
                    lock (threadIds)
                    {
                        if (!threadIds.Add(AsyncLock.ThreadId))
                        {
                            failure.Set();
                        }
                    }

                    countdown.Signal();
                    await abort.WaitAsync();
                });
            }

            if (WaitHandle.WaitAny(new[] {countdown.WaitHandle, failure.WaitHandle}) == 1)
            {
                Assert.True(false, "A duplicate thread id was found!");
            }

            abort.Release();
        }
    }
}