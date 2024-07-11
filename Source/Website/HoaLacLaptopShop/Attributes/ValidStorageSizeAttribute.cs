using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Attributes
{
    public class ValidStorageSizeAttribute : ValidationAttribute
    {
        private readonly int[] validSizes = { 256, 512, 1024 };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Consider null as valid if you want to allow nullable
            }

            if (value is int intValue)
            {
                if (validSizes.Contains(intValue))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.DisplayName} must be one of the following: {string.Join(", ", validSizes)} GB.");
            }

            return new ValidationResult($"Invalid value type for {validationContext.DisplayName}.");
        }
    }
}
