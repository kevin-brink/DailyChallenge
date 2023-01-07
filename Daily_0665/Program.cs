using Newtonsoft.Json;

namespace Daily_665
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var shortener = new URLShortener())
            {
                var url1 = "google.com";
                var url2 = "facebook.com";
                var url3 = "twitter.com";

                var shorter1 = shortener.Shorten(url1);
                var shorter2 = shortener.Shorten(url2);
                var shorter3 = shortener.Shorten(url3);

                var restored1 = shortener.Restore(shorter1);
                var restored2 = shortener.Restore(shorter2);
                var restored3 = shortener.Restore(shorter3);

                if (url1 == restored1)
                    Console.WriteLine("1 pass");
                else
                    Console.WriteLine("1 fail");

                if (url2 == restored2)
                    Console.WriteLine("2 pass");
                else
                    Console.WriteLine("2 fail");

                if (url3 == restored3)
                    Console.WriteLine("3 pass");
                else
                    Console.WriteLine("3 fail");
            }

            Console.ReadLine();
        }
    }
}