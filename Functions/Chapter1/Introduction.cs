using System;
using System.Collections.Generic;
using System.Linq;

namespace Functions
{
    public static class Introduction
    {
        public static Func<T, bool> NegatePredicate<T>(this Func<T, bool> predicate)
        {
            return t => !predicate(t);
        }

        public static IEnumerable<int> Quicksort(this IEnumerable<int> list)
        {
            if (list.Count() < 2)
            {
                return list;
            }

            if (list.Count() == 2 && list.ElementAt(0) > list.ElementAt(1))
            {
                return new List<int> {list.ElementAt(1), list.ElementAt(0)};
            }

            return null;
        }
    }
}
