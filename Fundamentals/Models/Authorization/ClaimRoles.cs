using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models.Authorization
{
    public class ClaimRoles
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string RoleId { get; set; }

        [DefaultValue(0)]
        public bool RoleApproved { get; set; }


    }
}