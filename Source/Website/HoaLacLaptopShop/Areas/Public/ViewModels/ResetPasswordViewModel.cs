using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
