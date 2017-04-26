using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using Fundamentals.Models.Validation;

namespace Fundamentals.Models.Movies
{
    public class MovieViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [MovieValidation]
        public DateTime ReleaseDate { get; set; }

        public Ganres Ganre { get; set; }

        [ForeignKey(nameof(Ganre))]
        [Required]
        public int GanreId { get; set; }

        public File File { get; set; }

        [ForeignKey(nameof(File))]
        public int? FileId { get; set; }
    }
}