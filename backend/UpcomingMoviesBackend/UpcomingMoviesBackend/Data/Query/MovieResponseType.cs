using GraphQL.Types;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Query
{
    class MovieResponseType : ObjectGraphType<PagedResult<Movie>>
    {
        public MovieResponseType()
        {
            Name = "MovieResponse";

            Field<ListGraphType<MovieType>>(
                name: "movies",
                resolve: x => x.Source.Results
            );

            Field(x => x.Page).Description("Current page");

            Field(x => x.TotalPages).Description("Total pages");

            Field(x => x.TotalResults).Description("Total results");

            Field(x => x.PageSize).Description("Results count on current page");

        }
    }
}
