/*

This problem was asked by Stripe.

Given an array of integers, find the first missing positive integer in linear time 
and constant space. In other words, find the lowest positive integer that does not
exist in the array. The array can contain duplicates and negative numbers as well.

For example, the input [3, 4, -1, 1] should give 2. The input [1, 2, 0] should give 3.

You can modify the input array in-place.

 */
using System.Collections;
using System.Net;
using System.Runtime.ExceptionServices;

using Xunit;

namespace Daily_0004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            Assert.Equal(2, sol.FirstMissing(new List<int>()  { 3, 4, -1, 1 }   ));
            Assert.Equal(3, sol.FirstMissing(new List<int>()  { 1, 2, 0 }       ));
            Assert.Equal(6, sol.FirstMissing(new List<int>()  { 1, 2, 3, 4, 5 } ));
            Assert.Equal(3, sol.FirstMissing(new List<int>()  { 0, 1, 2 }       ));
            Assert.Equal(1, sol.FirstMissing(new List<int>()  { }               ));
        }
    }

    public class Solution
    {
        public int FirstMissing(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int item = list[i];
                if (item > 0 && item < list.Count)
                    Swap(item - 1, i, list);
            }

            for (int j = 0; j < list.Count; ++j)
            {
                if (j + 1 != list[j])
                    return j + 1;
            }

            return list.Count + 1;
        }

        private void Swap(int i, int j, List<int> list)
        {
            var itemI = list[i];
            list[i] = list[j];
            list[j] = itemI;
        }
    }
}