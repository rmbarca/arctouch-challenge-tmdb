using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UpcomingMoviesBackend.Data.Remote;
using System.IO;

namespace UpcomingMoviesBackend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        // GET api/image/cover.jpg
        [HttpGet("{imagePath}")]
        public async Task<Stream> GetAsync(string imagePath)
        {
            var remote = new ImageRemoteDataSource();
            return await remote.GetImageAsync(imagePath);
        }
    }
}
