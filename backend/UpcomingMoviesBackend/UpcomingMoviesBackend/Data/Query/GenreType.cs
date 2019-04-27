using GraphQL.Types;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Query
{
    class GenreType : ObjectGraphType<Genre>
    {
        public GenreType()
        {
            Name = "Genre";

            Field(x => x.Id).Name("id");

            Field(x => x.Name).Name("name");

        }
    }
}
