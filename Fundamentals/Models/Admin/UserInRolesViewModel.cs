using System.Collections.Generic;

namespace Fundamentals.Models.Admin
{
    public class UserInRolesViewModel
    {
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string ClaimedRoleId { get; set; }

        public bool RoleApproved { get; set; }

        public List<AspNetRoleViewModel> Roles { get; set; }

        public bool IsDirty { get; set; }
    }
}