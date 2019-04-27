using GraphQL.Types;
using UpcomingMoviesBackend.Data.Remote;

namespace UpcomingMoviesBackend.Data.Query
{
    public class MovieQuery : ObjectGraphType
    {
        public MovieQuery(int id, MovieRemoteDataSource dataSource)
        {
            this.FieldAsync(
                name: "movie",
                description: "Movie",
                type: typeof(MovieType),
                resolve: async context => await dataSource.Get(id));

        }
    }
}
