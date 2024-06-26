using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Attributes
{
    public class ValidRamAttribute : ValidationAttribute
    {
        private readonly int[] validRAMs = { 8, 16, 32, 64 };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Consider null as valid if you want to allow nullable
            }

            if (value is int intValue)
            {
                if (validRAMs.Contains(intValue))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.DisplayName} must be one of the following: {string.Join(", ", validRAMs)} GB.");
            }

            return new ValidationResult($"Invalid value type for {validationContext.DisplayName}.");
        }
    }
}
