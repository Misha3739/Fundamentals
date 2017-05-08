using System.ComponentModel.DataAnnotations;

namespace Fundamentals.DomainModel
{
    public class Ganres
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
       
    }
}