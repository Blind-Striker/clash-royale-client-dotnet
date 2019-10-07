using Pekka.Core.Helpers;
using Pekka.Core.Tests.HelperTests.AsyncLockTests.Fakes;

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

using Xunit;

namespace Pekka.Core.Tests.HelperTests.AsyncLockTests
{
    // This class taken from another github repository
    // NeoSmart Technologies, AsyncLock: An async/await-friendly lock, (2019), GitHub repository, https://github.com/neosmart/AsyncLock
    // Commit https://github.com/neosmart/AsyncLock/tree/491ceb9a7bb391d0691ebc569e550e86885dec91
    // License https://github.com/neosmart/AsyncLock/blob/master/LICENSE

    public class ReentranceLockoutTests
    {
        private readonly Random _random = new Random((int) DateTime.UtcNow.Ticks);
        private CountdownEvent _countdown;
        private AsyncLock _lock;
        private LimitedResource _resource;

        private int DelayInterval => _random.Next(5, 10) * 10;

        private void ResourceSimulation(Action action)
        {
            _lock = new AsyncLock();

            //start n threads and have them obtain the lock and randomly wait, then verify
            var failure = new ManualResetEventSlim(false);
            _resource = new LimitedResource(() => { failure.Set(); });

            var testCount = 20;
            _countdown = new CountdownEvent(testCount);

            for (var i = 0; i < testCount; ++i) action();

            //MSTest does not support async test methods (apparently, but I could be wrong)
            //await Task.WhenAll(tasks);
            if (WaitHandle.WaitAny(new[] {_countdown.WaitHandle, failure.WaitHandle}) == 1)
                Assert.True(true, "More than one thread simultaneously accessed the underlying resource!");
        }

        private void ThreadEntryPoint()
        {
            using (_lock.Lock())
            {
                _resource.BeginSomethingDangerous();
                Thread.Sleep(DelayInterval);
                _resource.EndSomethingDangerous();
            }

            _countdown.Signal();
        }

        /// <summary>
        /// Tests whether the lock successfully prevents multiple threads from obtaining a lock simultaneously when sharing a function entrypoint.
        /// </summary>
        [Fact]
        public void MultipleThreadsMethodLockout()
        {
            ResourceSimulation(() =>
            {
                var t = new Thread(ThreadEntryPoint);
                t.Start();
            });
        }

        /// <summary>
        /// Tests whether the lock successfully prevents multiple threads from obtaining a lock simultaneously when sharing nothing.
        /// </summary>
        [Fact]
        public void MultipleThreadsLockout()
        {
            ResourceSimulation(() =>
            {
                var t = new Thread(() =>
                {
                    using (_lock.Lock())
                    {
                        _resource.BeginSomethingDangerous();
                        Thread.Sleep(DelayInterval);
                        _resource.EndSomethingDangerous();
                    }

                    _countdown.Signal();
                });

                t.Start();
            });
        }

        /// <summary>
        /// Tests whether the lock successfully prevents multiple threads from obtaining a lock simultaneously when sharing a local ThreadStart
        /// </summary>
        [Fact]
        public void MultipleThreadsThreadStartLockout()
        {
            void Work()
            {
                using (_lock.Lock())
                {
                    _resource.BeginSomethingDangerous();
                    Thread.Sleep(DelayInterval);
                    _resource.EndSomethingDangerous();
                }

                _countdown.Signal();
            }

            ResourceSimulation(() =>
            {
                var t = new Thread(Work);
                t.Start();
            });
        }

        [Fact]
        public void AsyncLockout()
        {
            ResourceSimulation(() =>
            {
                Task.Run(async () =>
                {
                    using (await _lock.LockAsync())
                    {
                        _resource.BeginSomethingDangerous();
                        Thread.Sleep(DelayInterval);
                        _resource.EndSomethingDangerous();
                    }

                    _countdown.Signal();
                });
            });
        }

        [Fact]
        public void AsyncDelayLockout()
        {
            ResourceSimulation(() =>
            {
                Task.Run(async () =>
                {
                    using (await _lock.LockAsync())
                    {
                        _resource.BeginSomethingDangerous();
                        await Task.Delay(DelayInterval);
                        _resource.EndSomethingDangerous();
                    }

                    _countdown.Signal();
                });
            });
        }

        [Fact]
        public void NestedAsyncLockout()
        {
            var taskStarted = new ManualResetEventSlim(false);
            var @lock = new AsyncLock();

            using (@lock.Lock())
            {
                Task task = Task.Run(async () =>
                {
                    taskStarted.Set();

                    using (await @lock.LockAsync())
                    {
                        Debug.WriteLine("Hello from within an async task!");
                    }
                });

                taskStarted.Wait();
                Assert.False(new TaskWaiter(task).WaitOne(100));
            }
        }
    }
}