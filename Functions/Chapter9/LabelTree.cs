using System;
using LaYumba.Functional.Data.LinkedList;
using static LaYumba.Functional.Data.LinkedList.LinkedList;

namespace Functions.Chapter9
{
    public class LabelTree<T>
    {
        public T Label { get; }
        public LaYumba.Functional.Data.LinkedList.List<LabelTree<T>> Subtrees { get; }

        public LabelTree(T label, LaYumba.Functional.Data.LinkedList.List<LabelTree<T>> subtrees)
        {
            Label = label;
            Subtrees = subtrees;
        }

        public override string ToString() => $"{Label}:{Subtrees}";

        public override bool Equals(object obj)
            => obj is LabelTree<T> otherTree &&
                   this.ToString() == otherTree.ToString();

        public override int GetHashCode()
        {
            return HashCode.Combine(Label, Subtrees);
        }
    }

    public static class LabelTreeExt
    {
        public static LabelTree<T> LabelTree<T>(T Label, LaYumba.Functional.Data.LinkedList.List<LabelTree<T>> Subtrees = null)
            => new LabelTree<T>(Label, Subtrees ?? List<LabelTree<T>>());

        public static LabelTree<R> Map<T, R>(this LabelTree<T> tree, Func<T, R> f)
        {
            return LabelTree(f(tree.Label), tree.Subtrees.Map(t => t.Map(f)));
        }
    }
}