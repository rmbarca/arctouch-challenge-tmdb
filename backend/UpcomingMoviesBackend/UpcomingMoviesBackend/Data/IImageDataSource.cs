using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UpcomingMoviesBackend.Data.Model;

namespace UpcomingMoviesBackend.Data
{
    public interface IImageDataSource
    {
        /// <summary>
        /// Gets availables images from specific movie in remote data source
        /// </summary>
        Task<ImageResponse> GetAsync(int movieId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets image from remote data source
        /// </summary>
        Task<Stream> GetImageAsync(string imagePath, CancellationToken cancellationToken = default(CancellationToken));
    }
}
