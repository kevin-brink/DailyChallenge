using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Daily_0665
{
    public class URLShortener : IDisposable
    {
        private List<ShortUrls> urls = new();
        private bool disposedValue;
        private string fileName = "C:\\source\\DailyChallenge\\DailyChallenge\\Daily_665\\urls.json";

        public URLShortener()
        {

            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                urls = JsonConvert.DeserializeObject<List<ShortUrls>>(json);
            }
        }

        public string Shorten(string url)
        {
            string randomString;
            while (true)
            {
                randomString = RandomString();
                if (!urls.Any(x => x.shortUrl == randomString))
                    break;
            }

            var shortened = new ShortUrls(url, randomString);
            urls.Add(shortened);

            return randomString;
        }

        public string Restore(string shortString)
        {
            var url = urls.FirstOrDefault(x => x.shortUrl == shortString);

            if (url is null)
                throw new Exception();

            return url.fullUrl;
        }

        private string RandomString(int length = 6)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public class ShortUrls
        {
            public string fullUrl { get; set; }
            public string shortUrl { get; set; }

            public ShortUrls(string fullUrl, string shortUrl)
            {
                this.fullUrl = fullUrl;
                this.shortUrl = shortUrl;
            }
        }

        public void Save()
        {
            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, urls);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                Save();

                // TODO: set large fields to null
                urls = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
