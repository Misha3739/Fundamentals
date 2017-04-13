using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Fundamentals.Models.Authorization
{
    public class MemberType
    {
        [Key]
        public int Id { get; set; }

       [Required]
       [StringLength(20)]
        public string RoleName { get; set; }

        [NotMapped]
        public MemberTypeEnum MemberTypeEnum { get; set; }
    }
}