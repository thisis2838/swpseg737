using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace HoaLacLaptopShop.Attribute
{
    public class ValidScreenSizeAttribute : ValidationAttribute
    {
        private readonly float[] validSizes = { 11.6f, 12f, 13.3f, 14f, 15.6f, 16f, 17f };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Consider null as valid if you want to allow nullable
            }

            if (value is float floatValue)
            {
                if (floatValue < 0)
                {
                    return new ValidationResult($"{validationContext.DisplayName} must be a non-negative value.");
                }

                if (validSizes.Contains(floatValue))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.DisplayName} must be one of the following: {string.Join(", ", validSizes)} inches.");
            }

            return new ValidationResult($"Invalid value type for {validationContext.DisplayName}.");
        }
    }

}
