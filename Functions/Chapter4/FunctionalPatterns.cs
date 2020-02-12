using System;
using System.Collections.Generic;
using System.Linq;

namespace Functions.Chapter4
{
    public static class FunctionalPatterns
    {
        public static ISet<R> Map<T, R>(this ISet<T> set, Func<T, R> f)
        {
            return set.Select(f).ToHashSet();
        }
    }
}