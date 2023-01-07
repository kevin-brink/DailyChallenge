namespace Daily_664
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var tree = new BinaryTree(new List<int>() { 1, 2, 5, 7, 89, 27, 5, 8, 15, 3, 3, 3, 5, 1, 1, 51, 51, 51, 51, 51, -20 });

            foreach (var number in tree.Traverse_InOrder())
                Console.Write($"{number}, ");
            Console.WriteLine();

            Console.ReadLine();

            Console.WriteLine(tree.MaxDepth());
            Console.ReadLine();

        }
    }
}