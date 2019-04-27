using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;
using System.Linq;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class MovieRemoteDataSource
    {
        private GenreResponse _genreResponse;

        private async void _loadGenres(CancellationToken cancellationToken = default(CancellationToken))
        {
            var genreDataSource = new GenreRemoteDataSource();
            _genreResponse = await genreDataSource.GetAsync(cancellationToken);
        }

        public async Task<MovieResponse> GetUpcomingAsync(int page = 1, CancellationToken cancellationToken = default(CancellationToken))
        {
            _loadGenres(cancellationToken);

            var clientMovie = new Client<MovieResponse>();
            var request = clientMovie.CreateRequest("/movie/upcoming");
            request.AddParameter(new KeyValuePair<string, string>("page", page.ToString()));

            var movieResponse = await request.GetAsync(cancellationToken);
            movieResponse.Movies = movieResponse.Movies.Select(movie => {
                _fillNestedMovieObjects(movie);
                return movie;
            });

            return movieResponse;
        }

        public async Task<Movie> Get(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            _loadGenres(cancellationToken);

            var clientMovie = new Client<Movie>();
            var request = clientMovie.CreateRequest(string.Format("/movie/{0}", id));

            var movie = await request.GetAsync(cancellationToken);
            _fillNestedMovieObjects(movie);

            return movie;
        }

        private void _fillNestedMovieObjects(Movie movie)
        {
            movie.Genres = _getMovieGenres(movie);
            movie.PosterPath = movie.PosterPath != null ? string.Format("/api/image{0}", movie.PosterPath) : movie.PosterPath;
            movie.BackdropPath = movie.BackdropPath != null ? string.Format("/api/image{0}", movie.BackdropPath) : movie.BackdropPath;
        }

        private IEnumerable<Genre> _getMovieGenres(Movie movie)
        {
            return _genreResponse.Genres.Where(g => movie.GenreIds != null && movie.GenreIds.Contains(g.Id));
        }
    }
}
