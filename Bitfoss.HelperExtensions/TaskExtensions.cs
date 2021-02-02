using System;
using System.Threading;
using System.Threading.Tasks;

namespace System.Threading.Tasks
{
    public static class TaskExtensions
    {
        public static async Task<R> Then<T, R>(this Task<T> task, Func<T, R> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));
            var result = await task;
            return func(result);
        }
        
        public static async Task<R> Then<R>(this Task task, Func<R> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));
            await task;
            return func();
        }

        public static async Task Then<T>(this Task<T> task, Action<T> action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            var result = await task;
            action(result);
        }
        
        public static async Task Then(this Task task, Action action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            await task;
            action();
        }
    }
}
