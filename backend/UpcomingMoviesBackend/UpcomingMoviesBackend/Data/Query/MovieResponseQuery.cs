using GraphQL.Types;
using UpcomingMoviesBackend.Data.Remote;

namespace UpcomingMoviesBackend.Data.Query
{
    public class MovieResponseQuery : ObjectGraphType
    {
        public MovieResponseQuery(MovieRemoteDataSource dataSource)
        {
            this.FieldAsync(
                type: typeof(MovieResponseType),
                name: "results",
                description: "Results",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "page" }),
                resolve: async context => {
                    var page = context.GetArgument<int>("page");
                    return await dataSource.GetUpcomingAsync(page);
                });

        }
    }
}
