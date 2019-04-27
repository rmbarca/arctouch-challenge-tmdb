using System.Collections.Generic;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class Client<T>
    {

        public Request<T> CreateRequest(string path)
        {
            var url = Startup.Api.Url;
            var key = new KeyValuePair<string, string>("api_key", Startup.Api.Key);

            var request = new Request<T>(string.Concat(url, path));
            request.AddParameter(key);
            return request;
        }

        public Request<T> CreateImageStreamRequest(string path)
        {
            var url = Startup.Api.ImageUrl;

            var request = new Request<T>(string.Concat(url, "/w500/", path));
            return request;
        }
    }
}
