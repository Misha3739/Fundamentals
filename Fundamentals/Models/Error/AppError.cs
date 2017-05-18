using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fundamentals.Models.Error
{
    public class AppError
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime OccuredTime { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        public string UserId { get; set; }
    }
}