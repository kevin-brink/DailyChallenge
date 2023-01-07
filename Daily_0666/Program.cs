namespace Daily_0666
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> list = new(new List<int> { 5, 10, 15, 20, 25 });

            var result = ListMaker(list, new List<int>(), new List<int>());
            var left = result.Item1;
            var right = result.Item2;

            var leftString = string.Join(", ", left);
            var rightString = string.Join(", ", right);

            Console.WriteLine($"({leftString}) - ({rightString}) = {AbsoluteDifference(result)}");
            Console.ReadLine();
        }

        static Tuple<List<int>, List<int>> ListMaker(Queue<int> arr, List<int> left, List<int> right)
        {
            if (arr.Count > 0)
            {
                var arrCopy = new Queue<int>(arr.ToList());
                var next = arrCopy.Dequeue();

                var toLeft = ListMaker(arrCopy, left.Concat(new[] { next }).ToList(), right);
                var toRight = ListMaker(arrCopy, left, right.Concat(new[] { next }).ToList());

                if (AbsoluteDifference(toLeft) > AbsoluteDifference(toRight))
                    return toRight;
                else
                    return toLeft;
            }
            else
                return new(left, right);
        }

        static int AbsoluteDifference(Tuple<List<int>, List<int>> results)
        {
            var left = results.Item1;
            var right = results.Item2;

            var difference = left.Sum() - right.Sum();
            if (difference < 0)
                difference *= -1;

            return difference;
        }
    }
}