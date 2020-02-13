using System;
using System.Collections.Generic;
using System.Linq;
using Functions.Chapter3;
using LaYumba.Functional;
using static LaYumba.Functional.F;

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
            var dictToReturn = new Dictionary<K, R>();
            foreach (KeyValuePair<K, T> t in dict)
            {
                dictToReturn.Add(t.Key, f(t.Value));
            }

            return dictToReturn;
        }

        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> f)
        {
            return opt.Bind(t => Some(f(t)));
        }

        public static IEnumerable<R> Map<T, R>(this IEnumerable<T> list, Func<T, R> f)
        {
            return list.Bind(t => List(f(t)));
        }

        public static Option<WorkPermit> GetWorkPermit(Dictionary<string, Employee> people, string employeeId)
        {
            return people.Lookup(x => x.Value.Id == employeeId).Bind(x => x.Value.WorkPermit).Where(x => x.Expiry >= DateTime.Now);
        }
    }
}