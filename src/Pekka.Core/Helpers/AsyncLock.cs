﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Pekka.Core.Helpers
{
    public class AsyncLock
    {
        //We do not have System.Threading.Thread.* on .NET Standard without additional dependencies
        //Work around is easy: create a new ThreadLocal<T> with a random value and this is our thread id :)
        private static readonly long UnlockedThreadId = 0; //"owning" thread id when unlocked
        private static int _globalThreadCounter;

        private static readonly ThreadLocal<int> _threadId = new ThreadLocal<int>(() => Interlocked.Increment(ref _globalThreadCounter));

        private readonly object _reentrancy = new object();

        //We are using this SemaphoreSlim like a posix condition variable
        //we only want to wake waiters, one or more of whom will try to obtain a different lock to do their thing
        //so long as we can guarantee no wakes are missed, the number of awakees is not important
        //ideally, this would be "friend" for access only from InnerLock, but whatever.
        private readonly SemaphoreSlim _retry = new SemaphoreSlim(0, 1);

        private long _owningId = UnlockedThreadId;
        private int _reentrances = 0;

        //We generate a unique id from the thread ID combined with the task ID, if any
        public static long ThreadId => (long) ((ulong) _threadId.Value << 32) | (uint) (Task.CurrentId ?? 0);

        public IDisposable Lock()
        {
            var @lock = new InnerLock(this);
            @lock.ObtainLock();

            return @lock;
        }

        public async Task<IDisposable> LockAsync()
        {
            var @lock = new InnerLock(this);
            await @lock.ObtainLockAsync();

            return @lock;
        }

        public async Task<IDisposable> LockAsync(CancellationToken ct)
        {
            var @lock = new InnerLock(this);
            await @lock.ObtainLockAsync(ct);

            return @lock;
        }

        private struct InnerLock : IDisposable
        {
            private readonly AsyncLock _parent;
#if DEBUG
            private bool _disposed;
#endif

            internal InnerLock(AsyncLock parent)
            {
                _parent = parent;
#if DEBUG
                _disposed = false;
#endif
            }

            public void Dispose()
            {
#if DEBUG
                Debug.Assert(!_disposed);
                _disposed = true;
#endif
                lock (_parent._reentrancy)
                {
                    Interlocked.Decrement(ref _parent._reentrances);

                    if (_parent._reentrances == 0)
                    {
                        //the owning thread is always the same so long as we are in a nested stack call
                        //we reset the owning id to null only when the lock is fully unlocked
                        _parent._owningId = UnlockedThreadId;
                        if (_parent._retry.CurrentCount == 0) _parent._retry.Release();
                    }
                }
            }

            internal async Task ObtainLockAsync()
            {
                while (!TryEnter())

                    //we need to wait for someone to leave the lock before trying again
                    await _parent._retry.WaitAsync();
            }

            internal async Task ObtainLockAsync(CancellationToken ct)
            {
                while (!TryEnter())

                    //we need to wait for someone to leave the lock before trying again
                    await _parent._retry.WaitAsync(ct);
            }

            internal void ObtainLock()
            {
                while (!TryEnter())

                    //we need to wait for someone to leave the lock before trying again
                    _parent._retry.Wait();
            }

            private bool TryEnter()
            {
                lock (_parent._reentrancy)
                {
                    Debug.Assert(_parent._owningId == UnlockedThreadId == (_parent._reentrances == 0));

                    if (_parent._owningId != UnlockedThreadId && _parent._owningId != ThreadId)

                        //another thread currently owns the lock
                        return false;

                    //we can go in
                    Interlocked.Increment(ref _parent._reentrances);
                    _parent._owningId = ThreadId;

                    return true;
                }
            }
        }
    }
}