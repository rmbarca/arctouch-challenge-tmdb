using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data
{
    public interface IMovieDataSource
    {
        /// <summary>
        /// Get upcoming movies from data source
        /// </summary>
        Task<PagedResult<Movie>> GetUpcomingAsync(int? id = null, int page = 1, string search = null, CancellationToken cancellationToken = default);

    }
}
