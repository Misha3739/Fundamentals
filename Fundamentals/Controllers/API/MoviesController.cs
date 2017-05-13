using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using AutoMapper;
using Fundamentals.DomainModel;
using Fundamentals.Models.DTO;
using Fundamentals.Models.Movies;

namespace Fundamentals.Controllers.API
{
    [Authorize]
    public class MoviesController : BaseController
    {
        //api/movies
        //DELETE
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var movie = _dbContext.Movies.SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                _dbContext.SaveChanges();
                return Ok();
            }
            return BadRequest($"Movie with id {id} does not exist");
        }

        //api/movies
        //GET
        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<MovieDTO> Get()
        {
            return _dbContext.Movies.Include(x=>x.Ganre)
                .Select(
                Mapper.Map<MovieViewModel,MovieDTO>);
        }
    }
}
