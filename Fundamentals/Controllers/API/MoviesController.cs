﻿using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fundamentals.API
{
    public class MoviesController : BaseController
    {
        //api/movies
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                return Ok();
            }
            else
            {
                return BadRequest($"Movie with id {id} does not exist");
            }
        }
    }
}
