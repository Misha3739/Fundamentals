using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fundamentals.Models.Authorization
{
    public class UserViewModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public MemberType MemberType { get; set; }

        [ForeignKey(nameof(MemberType))]
        public Int32 MemberTypeId { get; set; }


        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50)]
        public string LastName { get; set; }


        [StringLength(50)]
        public string Patronimic { get; set; }

        public DateTime? BirthDate { get; set; }

        public string Address { get; set; }


    }
}