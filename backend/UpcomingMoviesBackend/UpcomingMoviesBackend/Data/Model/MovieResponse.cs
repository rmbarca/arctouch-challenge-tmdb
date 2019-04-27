using Newtonsoft.Json;
using System.Collections.Generic;

namespace UpcomingMoviesBackend.Data.Model
{
    public class MovieResponse
    {
        [JsonProperty("results")]
        public IEnumerable<Movie> Movies { get; set; }

        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
