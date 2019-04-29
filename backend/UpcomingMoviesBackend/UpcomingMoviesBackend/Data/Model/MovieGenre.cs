namespace UpcomingMoviesBackend.Data.Model
{
    public class MovieGenre
    {
        public MovieGenre()
        {

        }
        public MovieGenre(Movie movie, Genre genre)
        {
            MovieId = movie.Id;
            GenreId = genre.Id;
            Movie = movie;
            Genre = genre;
        }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}
