using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data.Remote
{
    public class ImageRemoteDataSource
    {
        public async Task<ImageResponse> GetAsync(int movieId, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = new Client<ImageResponse>();
            var request = client.CreateRequest(string.Format("/movie/{0}/images", movieId));
            return await request.GetAsync(cancellationToken);
        }

        public async Task<Stream> GetImageAsync(string imagePath, CancellationToken cancellationToken = default(CancellationToken))
        {
            var client = new Client<Stream>();
            var request = client.CreateImageStreamRequest(imagePath);
            return await request.GetStreamAsync(cancellationToken);
        }
    }
}
