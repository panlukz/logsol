using System;
using System.ComponentModel.DataAnnotations;

namespace LogisticSolutions.CustomValidation
{
    public class DateRangeValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var specifiedDate = Convert.ToDateTime(value);
            var earliestPossibleDate = DateTime.Today;

            if (DateTime.Now.Hour > 12)
            {
                earliestPossibleDate.AddDays(1);
            }

            if (specifiedDate >= earliestPossibleDate)
            {
                return ValidationResult.Success;
            }
            
            return new ValidationResult("Wybrana data jest poza przedziałem");
        }
    }
}