using Microsoft.VisualBasic;

namespace Daily_0013
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string given = "hello person....how are you today? hahahaha";
            var result = DistinctSubstring(given, 2);
            Console.WriteLine($"Longest substring of '{given}' is '{result}'.");
        }

        static string DistinctSubstring(string given, int k)
        {
            var substring = "";

            for (int i = 0; i < given.Length; i++)
            {
                for (int j = i; j < given.Length; j++)
                {
                    IEnumerable<char> distinctCharacters = given[i..j].Distinct();
                    if (distinctCharacters.Count() > k)
                        break;

                    if (given[i..j].Length > substring.Length)
                            substring = given[i..j];
                }
            }

            return substring;
        }
    }
}