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

        public static IDictionary<K, R> Map<K, T, R>(this IDictionary<K, T> dict, Func<T, R> f)
        {
            var dictToReturn = new Dictionary<K,R>();
            foreach (KeyValuePair<K,T> t in dict)
            {
                dictToReturn.Add(t.Key, f(t.Value));
            }

            return dictToReturn;
        }
    }
}