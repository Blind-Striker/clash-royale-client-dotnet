using System.Threading;
using System.Threading.Tasks;

namespace Pekka.Core.Tests.HelperTests.AsyncLockTests.Fakes
{
    // This class taken from another github repository
    // NeoSmart Technologies, AsyncLock: An async/await-friendly lock, (2019), GitHub repository, https://github.com/neosmart/AsyncLock
    // Commit https://github.com/neosmart/AsyncLock/tree/491ceb9a7bb391d0691ebc569e550e86885dec91
    // License https://github.com/neosmart/AsyncLock/blob/master/LICENSE

    /// <summary>
    /// A guaranteed-safe method of "synchronously" waiting on tasks to finish. Cannot be used on .NET Core
    /// </summary>
    internal class TaskWaiter : EventWaitHandle
    {
        public TaskWaiter(Task task) : base(false, EventResetMode.ManualReset)
        {
            new Thread(async () =>
            {
                await task;
                Set();
            }).Start();
        }
    }
}