using System.ComponentModel.DataAnnotations.Schema;

namespace Fundamentals.Models.DTO
{
    [Table("UserInRolesDto")]
    public class UserInRolesDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ClaimedRoleId { get; set; }

        public bool RoleApproved { get; set; }

        public string RoleId { get; set; }

        public string RoleName { get; set; }

    }
}