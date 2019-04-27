using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class MovieRemoteDataSource
    {
        private GenreResponse _genreResponse;

        public async Task<MovieResponse> GetUpcomingAsync(int page = 1, CancellationToken cancellationToken = default(CancellationToken))
        {
            _ = await _loadGenres(cancellationToken);
            if (page == 0) page++;

            var clientMovie = new Client<MovieResponse>();
            var request = clientMovie.CreateRequest("/movie/upcoming");
            request.AddParameter(new KeyValuePair<string, string>("page", page.ToString()));

            var movieResponse = await request.GetAsync(cancellationToken);
            movieResponse.Movies = movieResponse.Movies.Select(movie => _fillNestedMovieObjects(movie));

            return movieResponse;
        }

        public async Task<Movie> Get(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            _ = await _loadGenres(cancellationToken);

            var clientMovie = new Client<Movie>();
            var request = clientMovie.CreateRequest(string.Format("/movie/{0}", id));
            var movie = await request.GetAsync(cancellationToken);

            return _fillNestedMovieObjects(movie);
        }

        private async Task<GenreResponse> _loadGenres(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (_genreResponse == null)
            {
                var genreDataSource = new GenreRemoteDataSource();
                _genreResponse = await genreDataSource.GetAsync(cancellationToken);
            }
            return _genreResponse;
        }

        private Movie _fillNestedMovieObjects(Movie movie)
        {
            movie.Genres = _getMovieGenres(movie);
            movie.PosterPath = movie.PosterPath != null ? string.Format("/image{0}", movie.PosterPath) : movie.PosterPath;
            movie.BackdropPath = movie.BackdropPath != null ? string.Format("/image{0}", movie.BackdropPath) : movie.BackdropPath;
            return movie;
        }

        private IEnumerable<Genre> _getMovieGenres(Movie movie)
        {
            return _genreResponse.Genres.Where(g => movie.GenreIds != null && movie.GenreIds.Contains(g.Id));
        }
    }
}
