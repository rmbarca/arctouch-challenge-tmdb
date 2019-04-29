using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class MovieRemoteDataSource: IMovieDataSource
    {
        private GenreResponse _genreResponse;

        public async Task<PagedResult<Movie>> GetUpcomingAsync(int? id = null, int page = 1, string search = null, CancellationToken cancellationToken = default)
        {
            _ = await _loadGenres(cancellationToken);
            if (page == 0) page++;

            var clientMovie = new Client<PagedResult<Movie>>();
            var request = clientMovie.CreateRequest("/movie/upcoming");
            request.AddParameter(new KeyValuePair<string, string>("page", page.ToString()));

            var movieResponse = await request.GetAsync(cancellationToken);
            movieResponse.Results = movieResponse.Results
                .Select(movie => _fillNestedMovieObjects(movie))
                .ToList();

            return movieResponse;
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
            movie.MovieGenres = _getMovieGenres(movie);
            movie.PosterPath = movie.PosterPath != null ? string.Format("/image{0}", movie.PosterPath) : movie.PosterPath;
            movie.BackdropPath = movie.BackdropPath != null ? string.Format("/image{0}", movie.BackdropPath) : movie.BackdropPath;
            return movie;
        }

        private ICollection<MovieGenre> _getMovieGenres(Movie movie)
        {
            var genres = _genreResponse.Genres.Where(g => movie.GenreIds != null && movie.GenreIds.Contains(g.Id));
            var movieGenres = genres.Select(genre => new MovieGenre(movie, genre));
            return movieGenres.ToList();
        }
    }
}
