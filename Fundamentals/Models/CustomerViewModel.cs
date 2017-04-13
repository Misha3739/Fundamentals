﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models
{
    public class CustomerViewModel 
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public  DateTime BirthDate { get; set; }
    }

    
}