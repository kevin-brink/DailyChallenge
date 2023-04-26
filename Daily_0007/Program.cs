using System.Diagnostics;

namespace Daily_0007
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var testCode = "111";
            var result = CountDecodings(testCode);
            var count = result.Count;
            Debug.Assert(count == 3);

            testCode = "251812101124";
            result = CountDecodings(testCode);
            count = result.Count;
            Debug.Assert(count == 40);

            testCode = Code.Encode("kevinbrink");
            result = CountDecodings(testCode);
            count = result.Count;
            Debug.Assert(count == 40);
        }

        public static List<string> CountDecodings(string encodedString)
        {
            if (encodedString.Length == 0)
                return new() { "" };

            List<string> decodedWords = new();

            if (encodedString.Length > 0)
            {
                string word = encodedString[0..1];
                int code = int.Parse(word);
                if (code == 0)
                    return decodedWords;

                if (code >= 1 && code <= 26)
                {
                    var possibleWords = CountDecodings(encodedString[1..]);
                    char decode = (char)(code + 'a' - 1);

                    for (int index = 0; index < possibleWords.Count; ++index)
                    {
                        possibleWords[index] = decode + possibleWords[index];
                    }

                    decodedWords.AddRange(possibleWords);
                }
            }

            if (encodedString.Length > 1)
            {
                string word = encodedString[0..2];
                int code = int.Parse(word);

                if (code >= 1 && code <= 26)
                {
                    var possibleWords = CountDecodings(encodedString[2..]);
                    char decode = (char)(code + 'a' - 1);

                    for (int index = 0; index < possibleWords.Count; ++index)
                    {
                        possibleWords[index] = decode + possibleWords[index];
                    }

                    decodedWords.AddRange(possibleWords);
                }
            }

            return decodedWords;
        }
    }
}