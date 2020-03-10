using LaYumba.Functional.Data.LinkedList;

namespace Functions.Chapter9
{
    public abstract class LabelTree<T>
    {

    }

    public class Node<T> : LabelTree<T>
    {
        public string Label { get; }
        public List<LabelTree<T>> Subtrees { get; }

        public Node(string label, List<LabelTree<T>> subtrees)
        {
            Label = label;
            Subtrees = subtrees;
        }
    }

    public static class LabelTree
    {
        public static LabelTree<T> Node<T>(string Label, List<LabelTree<T>> Subtrees)
            => new Node<T>(Label, Subtrees);
    }
}