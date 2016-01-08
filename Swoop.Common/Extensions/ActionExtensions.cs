using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Swoop.Common.Extensions
{
    public static class ActionExtensions
    {
        private class ActionTimer
        {
            public DateTime LastInvoke { get; set; }
            public bool InvokedWhileWait { get; set; }

            public ActionTimer()
            {
                LastInvoke = DateTime.UtcNow;
                InvokedWhileWait = false;
            }

            public void AnotherInvoke()
            {
                LastInvoke = DateTime.UtcNow;
                InvokedWhileWait = true;
            }
        }

        private static readonly ConcurrentDictionary<int, ActionTimer> Timers = new ConcurrentDictionary<int, ActionTimer>();

        
        public static void ThrottleAction(Action action, bool force = false, bool waitFirst = true, int throttleMs = 600)
        {
            throttleMs = Math.Max(20, throttleMs);
            ActionTimer a;

            var key = action.GetHashCode();
            if (Timers.ContainsKey(key))
            {
                Timers[key].LastInvoke = DateTime.UtcNow;
                Timers[key].AnotherInvoke();
                if (force)
                    Timers.TryRemove(key, out a);
                return;
            }
            if (force)
            {
                action();
                return;
            }
            Timers.GetOrAdd(key, new ActionTimer());
            ThreadPool.QueueUserWorkItem(x =>
            {
                if (waitFirst)
                {
                    while (DateTime.UtcNow.Subtract(Timers[key].LastInvoke).TotalMilliseconds < throttleMs)
                        Thread.Sleep(throttleMs);
                    action();
                }
                else
                {
                    action();
                    while (DateTime.UtcNow.Subtract(Timers[key].LastInvoke).TotalMilliseconds < throttleMs)
                        Thread.Sleep(throttleMs);
                    if (Timers[key].InvokedWhileWait)
                        action();
                }
                Timers.TryRemove(key, out a);
            });
        }
    }
}
