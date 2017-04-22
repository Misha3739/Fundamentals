using System;
using System.ComponentModel.DataAnnotations;
using Fundamentals.Models.Validation;

namespace Fundamentals.Models
{
    public class CustomerViewModel 
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [CustomerValidation]
        public  DateTime BirthDate { get; set; }


    }

    
}