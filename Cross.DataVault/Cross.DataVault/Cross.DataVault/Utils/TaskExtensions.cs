using System;
using System.Linq;
using System.Threading.Tasks;

using System.Diagnostics;

namespace Cross.DataVault.Utils
{
    public static class TaskExtensions
    {
        private static TimeSpan Default_Timeout_WhenRelease = new TimeSpan(0, 0, 60);
        private static TimeSpan Default_Timeout_WhenDebug = new TimeSpan(0, 0, 120);
        private static TimeSpan Default_WaitUntilComplete = new TimeSpan(0, 0, 1);

        /// <summary>
        /// Used for controlling the time that the Task is waited before continuing
        /// </summary>
        /// <param name="task"></param>
        /// <param name="waitTime"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static async Task WaitUntilComplete(this Task task, TimeSpan? waitTime, Action action)
        {
            var oWaitTime = waitTime.GetValueOrDefault(Default_WaitUntilComplete);
            await Task.WhenAny(task, Task.Delay(oWaitTime)).ContinueWith((e) =>
            {
                if (action != null)
                    action.Invoke();
            });
        }

        //Timeout Operations
        public static async Task TimeoutAfter(this Task task)
        {
            TimeSpan timeoutSpan;
            if (Debugger.IsAttached)
                timeoutSpan = Default_Timeout_WhenDebug;
            else
                timeoutSpan = Default_Timeout_WhenRelease;

            if (task != await Task.WhenAny(task, Task.Delay(timeoutSpan)).ConfigureAwait(false))
                throw new TimeoutException($"This operation has timed out after {timeoutSpan.Seconds} seconds");
        }

        public static async Task<T> TimeoutAfter<T>(this Task<T> task)
        {
            TimeSpan timeoutSpan;
            if (Debugger.IsAttached)
                timeoutSpan = Default_Timeout_WhenDebug;
            else
                timeoutSpan = Default_Timeout_WhenRelease;

            if (task == await Task.WhenAny(task, Task.Delay(timeoutSpan)).ConfigureAwait(false))
                return await task.ConfigureAwait(false);
            else
                throw new TimeoutException($"This operation has timed out after {timeoutSpan.Seconds} seconds");
        }
    }
}
