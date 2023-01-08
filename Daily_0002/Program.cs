/*
This problem was asked by Uber.

Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.

For example, if our input was [1, 2, 3, 4, 5], the expected output would be [120, 60, 40, 30, 24]. If our input was [3, 2, 1], the expected output would be [2, 3, 6].

Follow-up: what if you can't use division?
 */

using Shared;

namespace Daily_0002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var result = Solution.MultiplyList(list);
        }

        public class Solution
        {
            public static List<int> MultiplyList(List<int> list)
            {
                var resultList = new List<int>();

                for (int index = 0; index < list.Count; index++)
                    resultList.Add(Product(list.RemoveCopy(index)));

                return resultList;
            }

            private static int Product(List<int> list)
            {
                int product = 1;

                foreach(var num in list)
                    product *= num;

                return product;
            }
        }
    }
}