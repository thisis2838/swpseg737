using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //[Display(Name = "Remember me")]
        //public bool RememberMe { get; set; }
        //public string ReturnUrl { get; set; }
    }
}
