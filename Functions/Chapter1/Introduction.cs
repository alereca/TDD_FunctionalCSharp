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

        public static List<int> Quicksort(List<int> list)
        {
            if (list.Count() < 2)
            {
                return list;
            }

            if (list.Count() == 2)
            {
                if (list.ElementAt(0) > list.ElementAt(1))
                {
                    return new List<int> { list.ElementAt(1), list.ElementAt(0) };
                }

                return list;
            }

            var pivot = list.ElementAt(list.Count() / 2);

            var smaller = list.Where(x => x < pivot).ToList();
            var bigger = list.Where(x => x > pivot).ToList();

            return Quicksort(smaller)
                .Append(pivot)
                .Concat(Quicksort(bigger))
                .ToList();
        }
    }
}
