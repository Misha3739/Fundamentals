
using System;
using System.ComponentModel.DataAnnotations;


namespace Fundamentals.Models.Authorization
{
    public enum MemberTypeEnum
    {
        Admin = 1,
        Customer = 2,
        User = 3,
        None = 0
    };

    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        public string MemberTypeName => Enum.GetName(typeof(MemberTypeEnum), MemberType);

        public MemberTypeEnum MemberType { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronimic { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }


    }
}