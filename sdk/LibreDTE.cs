using System;

namespace LibreSDK
{
    public class LibreDTE
    {
        private Rest Rest;
        private const string libreDteUrl = "https://libredte.cl";

        public string LibreDteUrl
        {
            get { return libreDteUrl; }
        }

        public LibreDTE(string hash, string url)
        {
            this.Rest = new Rest(url);
            this.Rest.SetAuth(hash);
        }

        public LibreDTE(string user, string password, string url)
        {
            this.Rest = new Rest(url);
            this.Rest.SetAuth(user, password);
        }

        public LibreDTE(String hash) :
            this(hash, LibreDTE.libreDteUrl)
        {
        }

        public Rest Post<T>(String api, string jsonData)
        {
            this.Rest.Consume<T>("/api" + api, "POST", jsonData);
            return this.Rest;
        }

        public Rest Get<T>(String api, string jsonData, string contentType)
        {
            this.Rest.Consume<T>("/api" + api, "GET", null, contentType);
            return this.Rest;
        }
    }
}
