using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async void Execute()
        {
            try
            {
                var genreRemoteDataSource = new GenreRemoteDataSource();
                var movieRemoteDataSource = new MovieRemoteDataSource();

                var genres = (await genreRemoteDataSource.GetAsync())?.Genres;
                var moviesResponse = await movieRemoteDataSource.GetUpcomingAsync();

                var movies = moviesResponse?.Results?.ToList();
                while (moviesResponse.HasNext())
                {
                    moviesResponse = await movieRemoteDataSource.GetUpcomingAsync(moviesResponse.Page + 1);
                    movies.AddRange(moviesResponse.Results);
                }

                var movieGenresList = new List<MovieGenre>();
                movies?.ForEach(movie =>
                {
                    movieGenresList.AddRange(movie.MovieGenres);
                });

                using (var db = new MovieDatabaseContext())
                {
                    db.Database.ExecuteSqlCommand("DELETE FROM MovieGenres");
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand("DELETE FROM Movies");
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand("DELETE FROM Genres");
                    db.SaveChanges();

                    db.Movies.AddRange(movies);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(new SyncException("Error while synchronizing.", e));
            }
        } 
    }

    static class PagedResultExtension
    {
        /// <summary>
        /// Checks if has next page
        /// </summary>
        public static bool HasNext(this PagedResult<Movie> pagedResult)
        {
            return pagedResult.Page < pagedResult.TotalPages;
        }
    }
}
