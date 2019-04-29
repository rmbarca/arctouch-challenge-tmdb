using System.Collections.Generic;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class Client<T>
    {
        /// <summary>
        /// Creates a request instance for HTTP purposes
        /// </summary>
        public Request<T> CreateRequest(string path)
        {
            var url = Startup.Api.Url;
            var key = new KeyValuePair<string, string>("api_key", Startup.Api.Key);

            var request = new Request<T>(string.Concat(url, path));
            request.AddParameter(key);
            return request;
        }

        /// <summary>
        /// Creates a request instance for HTTP purposes but returning Stream instead of text
        /// </summary>
        public Request<T> CreateImageStreamRequest(string path)
        {
            var url = Startup.Api.ImageUrl;

            var request = new Request<T>(string.Concat(url, "/w500/", path));
            return request;
        }
    }
}
