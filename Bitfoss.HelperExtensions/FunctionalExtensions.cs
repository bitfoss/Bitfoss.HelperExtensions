using System;

namespace System
{
    public static class FunctionalExtensions
    {
        public static R Map<T,R>(this T t, Func<T, R> func)
        {
            _ = func ?? throw new ArgumentNullException(nameof(func));
            return func(t);
        }

        public static T Tee<T>(this T t, Action<T> action)
        {
            _ = action ?? throw new ArgumentNullException(nameof(action));
            action(t);
            return t;
        }
    }
}
