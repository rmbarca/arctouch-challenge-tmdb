using GraphQL.Types;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Query
{
    class MovieResponseType : ObjectGraphType<MovieResponse>
    {
        public MovieResponseType()
        {
            Name = "MoviesResponse";

            Field<ListGraphType<MovieType>>(
                name: "Movies",
                resolve: x => x.Source.Movies
            );

            Field(x => x.Page).Description("Current page");

            Field(x => x.TotalPages).Description("Total pages");

            Field(x => x.TotalResults).Description("Total results");

        }
    }
}
