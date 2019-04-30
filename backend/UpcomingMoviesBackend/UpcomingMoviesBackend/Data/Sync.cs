using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;
using UpcomingMoviesBackend.Data.Remote;
using UpcomingMoviesBackend.Exceptions;

namespace UpcomingMoviesBackend.Data
{
    public class Sync
    {
        /// <summary>
        /// Synchronize local and remote data sources.
        /// </summary>
        public async Task Execute()
        {
            try
            {
                var movies = await _fetchRemoteData();
                using (var db = new MovieDatabaseContext())
                {
                    _truncateTables(db);
                    _insertMovies(db, movies);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(new SyncException("Error while synchronizing.", e));
            }
        }

        /// <summary>
        /// Gets movies data from remote data source.
        /// </summary>
        /// <returns>Collection of movies</returns>
        private async Task<IEnumerable<Movie>> _fetchRemoteData()
        {
            var genreRemoteDataSource = new GenreRemoteDataSource();
            var movieRemoteDataSource = new MovieRemoteDataSource();

            var genres = (await genreRemoteDataSource.GetAsync())?.Genres;
            var moviesResponse = await movieRemoteDataSource.GetUpcomingAsync();

            var movies = moviesResponse?.Results?.ToList();
            while (moviesResponse.HasNext())
            {
                moviesResponse.Page++;
                moviesResponse = await movieRemoteDataSource.GetUpcomingAsync(page: moviesResponse.Page);
                movies.AddRange(moviesResponse.Results);
            }

            var movieGenresList = new List<MovieGenre>();
            movies?.ForEach(movie =>
            {
                movieGenresList.AddRange(movie.MovieGenres);
            });
            return movies;
        }

        /// <summary>
        /// Truncate tables in order to insert new data
        /// </summary>
        /// <param name="db">Local database context</param>
        private void _truncateTables(MovieDatabaseContext db)
        {
            db.Database.ExecuteSqlCommand("DELETE FROM MovieGenres");
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("DELETE FROM Movies");
            db.SaveChanges();
            db.Database.ExecuteSqlCommand("DELETE FROM Genres");
            db.SaveChanges();

            var moviesCount = db.Movies.Count();
            var genresCount = db.Genres.Count();
            var movieGenresCount = db.MovieGenres.Count();

            System.Diagnostics.Debug.WriteLine("moviesCount", moviesCount);
            System.Diagnostics.Debug.WriteLine("genresCount", genresCount);
            System.Diagnostics.Debug.WriteLine("movieGenresCount", movieGenresCount);
        }

        /// <summary>
        /// Insert new movies data
        /// </summary>
        /// <param name="db">Local database context</param>
        /// <param name="movies">Movies collection to be inserted</param>
        private void _insertMovies(MovieDatabaseContext db, IEnumerable<Movie> movies)
        {
            db.Movies.AddRange(movies);
            db.SaveChanges();
        }
    }
}
