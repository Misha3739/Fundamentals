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
                if (DateTime.Today.Year - customer.BirthDate.Year < 18)
                {
                    return new ValidationResult("Customer should be older than 18");
                }
            }
            return ValidationResult.Success;;
        }
    }
}