using Pekka.Core.Helpers;
using Pekka.Core.Tests.HelperTests.AsyncLockTests.Fakes;
using System.Diagnostics;
using System.Threading.Tasks;
using Xunit;

namespace Pekka.Core.Tests.HelperTests.AsyncLockTests
{
    // This class taken from another github repository
    // NeoSmart Technologies, AsyncLock: An async/await-friendly lock, (2019), GitHub repository, https://github.com/neosmart/AsyncLock
    // Commit https://github.com/neosmart/AsyncLock/tree/491ceb9a7bb391d0691ebc569e550e86885dec91
    // License https://github.com/neosmart/AsyncLock/blob/master/LICENSE

    public class ReentracePermittedTests
    {
        private readonly AsyncLock _lock = new AsyncLock();

        [Fact]
        public void NestedCallReentrance()
        {
            using (_lock.Lock())
            {
                using (_lock.Lock())
                {
                    Debug.WriteLine("Hello from NestedCallReentrance!");
                }
            }
        }

        [Fact]
        public void NestedAsyncCallReentrance()
        {
            Task task = Task.Run(async () =>
            {
                using (await _lock.LockAsync())
                {
                    using (await _lock.LockAsync())
                    {
                        Debug.WriteLine("Hello from NestedCallReentrance!");
                    }
                }
            });

            new TaskWaiter(task).WaitOne();
        }

        private void NestedFunction()
        {
            using (_lock.Lock())
            {
                Debug.WriteLine("Hello from another (nested) function!");
            }
        }

        [Fact]
        public void NestedFunctionCallReentrance()
        {
            using (_lock.Lock())
            {
                NestedFunction();
            }
        }
    }
}