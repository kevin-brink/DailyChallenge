using System.Diagnostics;

namespace Daily_0011
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Debug.WriteLine(string.Join(',', Autocomplete("de", new() { "dog", "deal", "deer" })));
        }

        public static IEnumerable<string> Autocomplete(string partialWord, List<string> wordList)
        {
            return wordList.Where(x => x.StartsWith(partialWord));
        }
    }
}