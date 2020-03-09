using System;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;

namespace Functions.Chapter9
{
    public static class ImmutableObjects
    {
        public static List<T> InsertAt<T>(this List<T> list, int index, T value, int i = 0)
            => list.Match(
                () => throw new IndexOutOfRangeException(),
                (head, tail) => i == index? 
                    List(value, List(head, tail)) 
                    : List(head, tail.InsertAt(index, value, ++i)) // (head1, (head2, (value, tail)))
            );

        public static List<T> RemoveAt<T>(this List<T> list, int index, int i = 0)
            => list.Match(
                () => throw new IndexOutOfRangeException(),
                (head, tail) => i == index? 
                    tail 
                    : List(head, tail.RemoveAt(index, ++i)) // (head1, (head2, tail)))
            );
    }
}