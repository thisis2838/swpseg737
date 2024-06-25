using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
