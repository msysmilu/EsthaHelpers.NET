using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace EsthaHelpers.Async
{
    /// <summary>
    /// Class for help with running async tasks in a sync manner.
    /// </summary>
    public static class TaskHelper
    {
        public static void RunTaskSynchronously(this Task t)
        {
            var task = Task.Run(async () => await t);
            task.Wait();
        }

        public static T RunTaskSynchronously<T>(this Task<T> t)
        {
            T res = default(T);
            var task = Task.Run(async () => res = await t);
            task.Wait();
            return res;
        }
    }
}