using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Local
{
    public class MovieLocalDataSource : IMovieDataSource
    {
        private MovieDatabaseContext _context;

        public MovieLocalDataSource(MovieDatabaseContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<Movie>> GetUpcomingAsync(int? id = null, int page = 1, string search = null, CancellationToken cancellationToken = default)
        {
            var results = _context.Movies
                .Include(m => m.MovieGenres)
                    .ThenInclude(mg => mg.Genre).AsQueryable();

            if (id.HasValue && id.Value > 0)
                results = results.Where(m => m.Id == id.Value);

            if (!string.IsNullOrWhiteSpace(search))
                results = results.Where(m => m.Title.ToLower().Contains(search.ToLower()));

            return results.GetPaged(page: page, pageSize: 20);
        }
    }
}
