using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Attributes
{
    public class ValidScreenResolutionAttribute : ValidationAttribute
    {
        private readonly string[] validResolutions = { "1920×1080", "1366×768", "1280×1024", "1024×768" };

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Consider null as valid if you want to allow nullable
            }

            if (value is string stringValue)
            {
                if (validResolutions.Contains(stringValue))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult($"{validationContext.DisplayName} must be one of the following: {string.Join(", ", validResolutions)}.");
            }

            return new ValidationResult($"Invalid value type for {validationContext.DisplayName}.");
        }
    }
}
