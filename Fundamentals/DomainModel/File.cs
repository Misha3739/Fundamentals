using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models.Movies
{
    public class File
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }
    }
}