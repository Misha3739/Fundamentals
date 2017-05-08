using System;
using System.ComponentModel.DataAnnotations;
using Fundamentals.DomainModel;
using Fundamentals.Models.Movies;

namespace Fundamentals.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MovieValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var movie = validationContext.ObjectInstance  as MovieViewModel;
            if (movie?.ReleaseDate.Year < 1900)
            {
                return new ValidationResult("Too old movie!");
            }
            return ValidationResult.Success;
        }
    }
}