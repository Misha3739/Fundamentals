using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Fundamentals.Models.Validation;

namespace Fundamentals.Models.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public GanreDTO Ganre { get; set; }

        public int GanreId { get; set; }

        public int? FileId { get; set; }
    }



}