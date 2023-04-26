using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_0007
{
    internal static class Code
    {
        public static readonly List<char> to6 = new() { '0', '1', '2', '3', '4', '5', '6' };
        public static readonly List<char> to2 = new() { '1', '2' };

        public static string Encode(string plainString)
        {
            string encodedString = "";
            foreach (char c in plainString.ToLower())
            {
                encodedString += ((int)(c - 'a' + 1)).ToString();
            }
            return encodedString;
        }

        public static string Decode(string encodedString)
        {
            var plainString = "";
            for (int index = 0; index < encodedString.Length; index++)
            {
                var curr = encodedString[index];
                if (index + 1 < encodedString.Length)
                {
                    var next = encodedString[index + 1];
                    if (to2.Contains(curr))
                    {
                        if (curr == '1' || (curr == '2' && to6.Contains(next)))
                        {
                            plainString += DecodeChar(new string(curr, next));
                            ++index;
                            continue;
                        }
                    }
                }

                plainString += DecodeChar(curr.ToString());
            }

            return plainString;
        }

        public static string DecodeChar(string encodedChar) 
        {
            int encodedInt = int.Parse(encodedChar);
            char plainChar = (char)(encodedInt + 'a');

            return plainChar.ToString();
        }
    }
}
