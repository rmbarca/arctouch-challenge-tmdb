using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Moq;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace XUnitTestProject.Fake
{
    class MovieDatabaseContextFake
    {
        private Mock<IMovieContext> _mock;

        public MovieDatabaseContextFake()
        {

            var movieFake = new MovieFake();
            var movies = movieFake.Movies_25_Entries;

            _mock = new Mock<IMovieContext>();
            var moviesMock = new Mock<DbSet<Movie>>();
            moviesMock.As<IQueryable<Movie>>().Setup(m => m.Provider).Returns(movies.AsQueryable().Provider);

            _mock.Setup(p => p.Movies).Returns(moviesMock.Object);
        }

        public IMovieContext GetFake()
        {
            return _mock.Object;
        }
    }

    class MovieFake
    {
        public IList<Movie> Movies_25_Entries { get; internal set; }

        public MovieFake()
        {
            Movies_25_Entries = new List<Movie>();

            var genreAction = new Genre()
            {
                Id = 1,
                Name = "Action"
            };
            var genreSciFi = new Genre()
            {
                Id = 2,
                Name = "Sci-Fi"
            };

            for (int i = 1; i <= 25; i++)
            {
                var movie = new Movie()
                {
                    Id = i,
                    Adult = false,
                    Title = "Test title"

                };
                var movieGenres = new List<MovieGenre>() {
                            new MovieGenre()
                            {
                                GenreId = 1,
                                Genre = genreAction,
                                MovieId = movie.Id,
                                Movie = movie
                            },
                            new MovieGenre()
                            {
                                GenreId = 2,
                                Genre = genreSciFi,
                                MovieId = movie.Id,
                                Movie = movie
                            }
                        };
                movie.MovieGenres = movieGenres;

                Movies_25_Entries.Add(movie);
            }
        }
    }
}
