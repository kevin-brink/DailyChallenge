using System.Diagnostics;

namespace Daily_0007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCode = "111";
            var count = CountDecodings(testCode);
            Debug.Assert(count == 3);

            testCode = "251812101124";
            count = CountDecodings(testCode);
            Debug.Assert(count == 40);
        }

        public static int CountDecodings(string encodedString)
        {
            if (encodedString.Length == 0)
                return 1;

            int possible = 0;

            if (encodedString.Length > 0)
            {
                string word = encodedString[0..1];
                int code = int.Parse(word);

                if (code >= 1 && code <= 26)
                    possible += CountDecodings(encodedString[1..]);

                if (code == 0)
                    return 0;
            }

            if (encodedString.Length > 1)
            {
                string word = encodedString[0..2];
                int code = int.Parse(word);

                if (code >= 1 && code <= 26)
                    possible += CountDecodings(encodedString[2..]);                
            }

            return possible;
        }
    }
}