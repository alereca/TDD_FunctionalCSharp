using System;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;

namespace Functions.Chapter9
{
    public static class ImmutableObjects
    {
        /*
        public static List<T> InsertAt<T>(this List<T> list, int i, T value, int j = 0)
            => list.Match(
                () => throw new IndexOutOfRangeException(),
                (head, tail) => j == i? 
                    List(value, List(head, tail)) 
                    : List(head, tail.InsertAt(i, value, ++j)) // (head1, (head2, (value, tail)))
            );

        public static List<T> RemoveAt<T>(this List<T> list, int i, int j = 0)
            => list.Match(
                () => throw new IndexOutOfRangeException(),
                (head, tail) => j == i? 
                    tail 
                    : List(head, tail.RemoveAt(i, ++j)) // (head1, (head2, tail)))
            );
        */

        // Cleaner implementations for insertAt and removeAt 

        public static List<T> InsertAt<T>(this List<T> list, int i, T value)
            => i == 0 ?
                  List(value, list)
                : List(list.Head, list.Tail.InsertAt(i - 1, value)); // (head1, (head2, (value, tail)))

        public static List<T> RemoveAt<T>(this List<T> list, int i)
            => i == 0 ?
                  list.Tail
                : List(list.Head, list.Tail.RemoveAt(i - 1)); // (head1, (head2, tail)))

        public static List<T> TakeWhile<T>(this List<T> list, Func<T, bool> predicate)
            => list.Match(
                () => list,
                (head, tail) => predicate(list.Head) ?
                      List(list.Head, list.Tail.TakeWhile(predicate)) // (head1, (head2, empty))
                    : List<T>()
            );

        public static List<T> DropWhile<T>(this List<T> list, Func<T, bool> predicate)
            => list.Match(
                () => list,
                (head, tail) => predicate(head) ?
                      tail.DropWhile(predicate) // Ignore heads one after another
                    : list // until the predicate is invalid so the rest of the list is returned
            );

        public static System.Collections.Generic.IEnumerable<T> TakeWhile<T>(this System.Collections.Generic.IEnumerable<T> list, Func<T, bool> predicate)
        {
            foreach (T item in list)
            {
                if (!predicate(item))
                {
                    yield break;
                }

                yield return item;
            }
        }

        public static System.Collections.Generic.IEnumerable<T> DropWhile<T>(this System.Collections.Generic.IEnumerable<T> list, Func<T, bool> predicate)
        {
            bool clean = true;
            foreach (var item in list)
            {
                if (!clean || !predicate(item))
                {
                    yield return item;
                    clean = false;
                }
            }
        }
    }
}