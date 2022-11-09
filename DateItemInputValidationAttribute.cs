using System.ComponentModel.DataAnnotations;
using TajerTest.InputsOutPuts;

namespace TajerTest
{
    public class DateItemInputValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var itemInPut = validationContext.ObjectInstance as ItemInput;
            if (itemInPut.Date.Year < 2000)
                return new ValidationResult("Date is Invalid");
            return ValidationResult.Success;

            
        }
    }
}
