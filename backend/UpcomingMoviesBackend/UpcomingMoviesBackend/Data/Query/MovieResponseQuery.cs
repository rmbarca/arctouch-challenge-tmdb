using GraphQL.Types;

namespace UpcomingMoviesBackend.Data.Query
{
    public class MovieResponseQuery : ObjectGraphType
    {
        public MovieResponseQuery(IMovieDataSource dataSource)
        {
            this.FieldAsync(
                type: typeof(MovieResponseType),
                name: "results",
                description: "Results",
                arguments: new QueryArguments(
                    new QueryArgument<IntGraphType> { Name = "id" },
                    new QueryArgument<IntGraphType> { Name = "page" },
                    new QueryArgument<StringGraphType> { Name = "search" }
                    ),
                resolve: async context => {
                    var id = context.GetArgument<int>("id");
                    var page = context.GetArgument<int>("page");
                    var search = context.GetArgument<string>("search");
                    var results = await dataSource.GetUpcomingAsync(id, page, search);
                    return results;
                });
                
        }
    }
}
