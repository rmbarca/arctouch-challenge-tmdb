using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class Request<T>
    {
        private string _path;
        private List<KeyValuePair<string, string>> _queryParameters;
        private string _url
        {
            get
            {
                return _path
                    + (_queryParameters.Count == 0 ? "" : "?")
                    + string.Join("&", _queryParameters.Select(r => r.Key + "=" + r.Value));
            }
        }

        public Request(string path)
        {
            _path = path;
            _queryParameters = new List<KeyValuePair<string, string>>();
        }

        public void AddParameter(KeyValuePair<string, string> parameter)
        {
            _queryParameters.Add(parameter);
        }

        public async Task<T> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = new HttpClient())
            {
                var data = await client.GetStringAsync(_url);
                try
                {
                    var deserialized = JsonConvert.DeserializeObject<T>(data);
                    return deserialized;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    throw e;
                }
            }
        }

        public async Task<Stream> GetStreamAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var stream = await client.GetStreamAsync(_url);
                    return stream;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    throw e;
                }
            }
        }
    }
}
