using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UpcomingMoviesBackend.Data.Local
{
    public abstract class PagedResultBase
    {
        [JsonProperty("page")]
        public int Page { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

        [JsonProperty("total_results")]
        public int TotalResults { get; set; }

        public int PageSize { get; set; }

        public int FirstRowOnPage
        {

            get { return (Page - 1) * PageSize + 1; }
        }

        public int LastRowOnPage
        {
            get { return Math.Min(Page * PageSize, TotalResults); }
        }

        /// <summary>
        /// Checks if has next page
        /// </summary>
        public bool HasNext()
        {
            return Page < TotalPages;
        }
    }

    public class PagedResult<T> : PagedResultBase where T : class
    {
        [JsonProperty("results")]
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            Results = new List<T>();
        }
    }
}
