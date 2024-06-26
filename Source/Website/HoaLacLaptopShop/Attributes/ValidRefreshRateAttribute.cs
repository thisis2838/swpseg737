using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Attributes
{
    public class ValidRefreshRateAttribute : ValidationAttribute
    {
        private readonly int[] validRates = { 60, 144, 165 };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Consider null as valid if you want to allow nullable
            }

            if (value is int intValue)
            {
                if (validRates.Contains(intValue))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.DisplayName} must be one of the following: {string.Join(", ", validRates)} Hz.");
            }

            return new ValidationResult($"Invalid value type for {validationContext.DisplayName}.");
        }
    }
}
