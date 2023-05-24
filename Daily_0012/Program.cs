using System.Diagnostics;

namespace Daily_0012
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var results = Steps(4, new List<int>() { 1, 2 });
            PrintResults(results);

            results = Steps(8, new List<int>() { 1, 3, 5});
            PrintResults(results);
        }

        static IEnumerable<int[]> Steps(int n, IEnumerable<int> steps, int[] path = null)
        {
            if (n == 0) 
                return new List<int[]>() { path };
            path = path ?? new int[0];

            var list = new List<int[]>();
            foreach (var step in steps)
            {
                if (n - step < 0) continue;

                list.AddRange(Steps(n - step, steps, path.Concat(new int[] { step }).ToArray()));
            }

            return list;
        }   

        public static void PrintResults(IEnumerable<int[]> results)
        {
            Debug.WriteLine($"There are {results.Count()} valid paths:");
            foreach (var result in results)
            {
                string resultString = " - " + string.Join(", ", result);
                Debug.WriteLine(resultString);
            }
        }
    }
}