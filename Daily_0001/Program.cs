using System.Reflection;

namespace Daily_0001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 4, 4, 6, 7, 9, 12, 19, 21, 30, 100 };

            for (int target = 1; target <= 100; ++target)
            {
                var result = Solution.ExactlyTwo(list, target);
                result.Reverse();

                if (result.Count == 0)
                    Console.WriteLine($"No solutions for {target}");
                else
                {
                    bool pass = true;
                    foreach (var item in result)
                    {
                        if (!list.Contains(item))
                            pass = false;
                    }

                    if (target != result.Sum())
                        pass = false;

                    if (pass)
                        Console.Write("Pass: ");
                    else
                        Console.Write("Fail: ");

                    Console.WriteLine($"{target} = {string.Join(" + ", result)}");
                }
            }

            Console.ReadLine();
        }

        public static class Solution
        {
            public static List<int> SumRecursive(List<int> list, int target, int current = 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (current + list[i] == target && current > 0)
                        return new() { list[i] };

                    if (current + list[i] > target)
                        continue;

                    var newList = list.GetRange(i + 1, list.Count - i - 1);
                    var sum = SumRecursive(newList, target, current + list[i]);
                    if (sum.Count > 0)
                    {
                        sum.Add(list[i]);
                        return sum;
                    }
                }

                return new();
            }

            public static List<int> ExactlyTwo(List<int> list, int target)
            {
                foreach(int num in list)
                {
                    if (list.Contains(target - num))
                        return new() { num, target - num };
                }

                return new();
            }
        }
    }
}