﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UpcomingMoviesBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpcomingMoviesController : ControllerBase
    {
        // GET api/upcomingmovies
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/upcomingmovies/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/upcomingmovies
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/upcomingmovies/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/upcomingmovies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
