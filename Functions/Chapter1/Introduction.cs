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

            var pivot = list.ElementAt(list.Count() / 2);

            var smaller = list.Where(x => x < pivot).ToList();
            var bigger = list.Where(x => x > pivot).ToList();

            return Quicksort(smaller)
                .Append(pivot)
                .Concat(Quicksort(bigger))
                .ToList();
        }

        public static List<T> GenericQuicksort<T>(List<T> list, Comparison<T> comparison)
        {
            if (list.Count() < 2)
            {
                return list;
            }

            var pivot = list.ElementAt(list.Count() / 2);

            var smaller = list.Where(x => comparison(x, pivot) < 0).ToList();
            var bigger = list.Where(x => comparison(x, pivot) > 0).ToList();

            return GenericQuicksort(smaller, comparison)
                .Append(pivot)
                .Concat(GenericQuicksort(bigger, comparison))
                .ToList();
        }
    }
}
