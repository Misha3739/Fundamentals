using System;
using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models
{
    public class CustomerViewModel 
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public  DateTime BirthDate { get; set; }
    }

    
}