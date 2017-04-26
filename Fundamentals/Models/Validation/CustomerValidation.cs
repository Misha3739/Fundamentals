using System;
using System.ComponentModel.DataAnnotations;

namespace Fundamentals.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomerValidation : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance  as CustomerViewModel;
            if (customer != null)
            {
                if (customer.BirthDate.Year < 1900)
                {
                    return new ValidationResult("Too old customer!");
                }
                if (DateTime.Today.Year - customer.BirthDate.Year < 18)
                {
                    return new ValidationResult("Customer should be older than 18");
                }
            }
            return ValidationResult.Success;;
        }
    }
}