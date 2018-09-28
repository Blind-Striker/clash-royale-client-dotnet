using System;
using System.Threading;
using System.Threading.Tasks;

namespace Pekka.Core.Helpers
{
    public static class AsyncHelper
    {
        private static readonly TaskFactory MyTaskFactory = new
            TaskFactory(CancellationToken.None,
                TaskCreationOptions.None,
                TaskContinuationOptions.None,
                TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return MyTaskFactory
                .StartNew<Task<TResult>>(func)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            MyTaskFactory
                .StartNew<Task>(func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }

        public static TResult RunSync<TResult>(this Task<TResult> task)
        {
            return MyTaskFactory
                .StartNew<Task<TResult>>(() => task)
                .Unwrap<TResult>()
                .GetAwaiter()
                .GetResult();
        }

        public static void RunSync(this Task func)
        {
            MyTaskFactory
                .StartNew<Task>(() => func)
                .Unwrap()
                .GetAwaiter()
                .GetResult();
        }
    }
}
