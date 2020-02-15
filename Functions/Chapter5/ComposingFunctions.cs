using System;

namespace Functions.Chapter5
{
    public static class ComposingFunctions
    {
        public static Func<S,R> Compose<S, T, R>(this Func<T, R> f, Func<S, T> g)
        {
            return s => f(g(s));
        }
    }
}