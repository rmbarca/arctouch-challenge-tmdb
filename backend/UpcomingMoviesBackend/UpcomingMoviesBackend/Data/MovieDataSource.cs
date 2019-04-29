using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data
{
    public class MovieDataSource : IMovieDataSource
    {
        private IMovieDataSource _localDataSource;
        private Sync _sync;

        public MovieDataSource(MovieDatabaseContext _context)
        {
            _localDataSource = new MovieLocalDataSource(_context);
            _sync = new Sync();
        }

        public async Task<PagedResult<Movie>> GetUpcomingAsync(int? id = null, int page = 1, string search = null, CancellationToken cancellationToken = default)
        {
            var result = await _localDataSource.GetUpcomingAsync(id, page, search, cancellationToken);
            _sync.Execute();
            return result;
        }
    }
}
