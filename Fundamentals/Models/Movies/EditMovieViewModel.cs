using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundamentals.Models.Movies
{
    public class EditMovieViewModel
    {
        public MovieViewModel Movie { get; set; }

        public IEnumerable<Ganres> Ganres { get; set; }
    }
}