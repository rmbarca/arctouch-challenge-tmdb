using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class GenreRemoteDataSource: IGenreDataSource
    {
        public async Task<GenreResponse> GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = new Client<GenreResponse>();
            var request = client.CreateRequest("/genre/movie/list");
            return await request.GetAsync(cancellationToken);
        }
    }
}
