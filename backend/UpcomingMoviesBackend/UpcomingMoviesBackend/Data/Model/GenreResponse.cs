using Newtonsoft.Json;
using System.Collections.Generic;

namespace UpcomingMoviesBackend.Data.Model
{
    public class GenreResponse
    {
        [JsonProperty("genres")]
        public IEnumerable<Genre> Genres { get; set; }
    }
}
