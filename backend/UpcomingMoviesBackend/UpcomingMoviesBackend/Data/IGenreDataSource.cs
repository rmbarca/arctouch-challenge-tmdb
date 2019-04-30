using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data
{
    public interface IGenreDataSource
    {
        /// <summary>
        /// Gets genres from remote data source
        /// </summary>
        Task<GenreResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken));

    }
}
