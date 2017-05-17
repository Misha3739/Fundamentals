using System;

namespace Fundamentals.Models.DTO
{
    public class AspNetUserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }
       
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string ClaimedRoleId { get; set; }

        public bool RoleApproved { get; set; }
    }
}