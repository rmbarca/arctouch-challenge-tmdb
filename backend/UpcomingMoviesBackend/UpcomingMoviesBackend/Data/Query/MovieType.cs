using GraphQL.Types;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Query
{
    class MovieType : ObjectGraphType<Movie>
    {
        public MovieType()
        {
            Name = "Movie";

            Field(x => x.Id).Name("id");

            Field(x => x.Title).Name("title");

            Field(type: typeof(StringGraphType), name: "posterPath", resolve: x => x.Source.PosterPath);

            Field(type: typeof(StringGraphType), name: "backdropPath", resolve: x => x.Source.BackdropPath);

            Field(type: typeof(ListGraphType<GenreType>), name: "genres", resolve: x => x.Source.Genres);

            Field(type: typeof(StringGraphType), name: "releaseDate", resolve: x => x.Source.ReleaseDate);

            Field(type: typeof(StringGraphType), name: "overview", resolve: x => x.Source.Overview);

        }
    }
}
