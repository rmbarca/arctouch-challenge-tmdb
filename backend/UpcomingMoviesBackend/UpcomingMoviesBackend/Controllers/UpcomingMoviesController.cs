using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraphQL;
using GraphQL.Types;
using UpcomingMoviesBackend.Data.Remote;
using UpcomingMoviesBackend.Data.Query;

namespace UpcomingMoviesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingMoviesController : ControllerBase
    {
        // POST api/upcomingmovies/5
        // {"query":"{movie{overview,title,releaseDate,posterPath,backdropPath,genres{name}}}"}
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new MovieQuery(id, new MovieRemoteDataSource())
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

        // POST api/upcomingmovies
        // {"query":"{results(page:14){page,totalPages,totalResults,movies{title,releaseDate,posterPath,backdropPath,genres{name}}}}"}
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            var inputs = query.Variables.ToInputs();

            var schema = new Schema()
            {
                Query = new MovieResponseQuery(new MovieRemoteDataSource())
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
