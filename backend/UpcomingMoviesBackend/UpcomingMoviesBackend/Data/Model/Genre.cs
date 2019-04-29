using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace UpcomingMoviesBackend.Data.Model
{
    public class Genre
    {
        [JsonProperty("id")]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
