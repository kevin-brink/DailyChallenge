using Shared;

namespace Daily_0008
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>(0);      //    0
            tree.Root.Left = new Node<int>(1);                  //   / \
            tree.Root.Right= new Node<int>(0);                  //  1   0
            tree.Root.Right.Left = new Node<int>(1);            //     / \
            tree.Root.Right.Right = new Node<int>(0);           //    1   0
            tree.Root.Right.Left.Left = new Node<int>(1);       //   / \
            tree.Root.Right.Left.Right = new Node<int>(1);      //  1   1

            var count = CountUnival(tree);
        }

        public static int CountUnival<T>(BinaryTree<T> tree) where T :IComparable
            => CountUnival(tree.Root);

        public static int CountUnival<T>(Node<T>? node) where T : IComparable
        {

            if (node is null)
                return 0;

            var count = 0;

            if (IsUnival(node))
                ++count;

            if (node.Left is not null)
                count += CountUnival(node.Left);

            if (node.Right is not null)
                count += CountUnival(node.Right);

            return count;
        }

        public static bool IsUnival<T>(Node<T> node) where T : IComparable
        {
            return IsUnival(node, node.Value);
        }

        public static bool IsUnival<T>(Node<T> node, T value) where T : IComparable
        {
            if (!node.Value.Equals(value)) return false;

            if (node.Left is not null && !IsUnival(node.Left, value)) return false;

            if (node.Right is not null && !IsUnival(node.Right, value)) return false;

            return true;
        }
    }
}