using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}
