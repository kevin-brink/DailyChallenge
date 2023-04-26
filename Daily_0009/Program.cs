using System.Diagnostics;

namespace Daily_0009
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] test;
            int result;

            test = new[] { 2, 4, 6, 2, 5 };
            result = MaxSum(test);
            Debug.Assert(result == 13);

            test = new[] { 5, 1, 1, 5 };
            result = MaxSum(test);
            Debug.Assert(result == 10);
        }

        public static int MaxSum(int[] nums)
        {
            int max = int.MinValue;
            if (nums.Length > 0)
            {
                var pick = nums[0];
                int sum;
                if (nums.Length > 2)
                    sum = pick + MaxSum(nums[2..]);
                else 
                    sum = pick;
                
                if (sum > max) max = sum;
            }

            if (nums.Length > 1)
            {
                var pick = nums[1];
                int sum;
                if (nums.Length > 3)
                    sum = pick + MaxSum(nums[3..]);
                else
                    sum = pick;

                if (sum > max) max = sum;
            }

            return max;
        }
    }
}