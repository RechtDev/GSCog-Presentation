using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCRecap.Models.ValidationClasses
{
    public class DateValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var userDate = (DateTime)value;
            var nowDate = DateTime.Now.Date;
            if(nowDate.CompareTo(userDate.Date) <0)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Flights must be booked on or after the current date.");
        }
    }
}
