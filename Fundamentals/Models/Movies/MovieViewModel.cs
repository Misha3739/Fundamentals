using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundamentals.Models.Movies
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name cannot be null or empty")]
        [StringLength(50)]
        public string Name { get; set; }

        public byte[] Content { get; set; }

        public Ganres Ganre { get; set; }

        [ForeignKey(nameof(Ganre))]
        [Required]
        public int GanreId { get; set; }
    }
}