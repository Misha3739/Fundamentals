using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models
{
    public class MovieViewModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Content { get; set; }
    }
}