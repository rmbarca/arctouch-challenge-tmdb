using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using UpcomingMoviesBackend.Data.Query;
using Microsoft.AspNetCore.Cors;
using UpcomingMoviesBackend.Data.Local;
using UpcomingMoviesBackend.Data;

namespace UpcomingMoviesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingMoviesController : ControllerBase
    {
        private readonly MovieDatabaseContext _context;

        public UpcomingMoviesController(MovieDatabaseContext context)
        {
            _context = context;
        }

        // POST api/upcomingmovies
        // {"query":"{results(page:1, id: 0, search: \"avenger\"){page,totalPages,totalResults,movies{id,title,releaseDate,posterPath,backdropPath,genres{id,name}}}}"}
        [EnableCors]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new MovieQuery(new MovieDataSource(_context))
            };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;
                _.OperationName = query.OperationName;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
