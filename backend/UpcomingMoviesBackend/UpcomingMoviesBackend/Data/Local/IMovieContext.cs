using Microsoft.EntityFrameworkCore;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Local
{
    public interface IMovieContext
    {
        DbSet<Genre> Genres { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<MovieGenre> MovieGenres { get; set; }
    }
}
