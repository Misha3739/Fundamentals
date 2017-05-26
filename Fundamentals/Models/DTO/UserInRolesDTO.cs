using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fundamentals.Models.DTO
{
    public class UserInRolesDto
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ClaimedRoleId { get; set; }

        public bool RoleApproved { get; set; }

        public List<AspNetRoleDto> Roles { get; set; }
    }
}