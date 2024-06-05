using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.ViewModels
{
    public class RegisterViewModel : User
    {
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }

    public class UserEditViewModel : User
    {
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        [MinLength(8)]
        public string? NewPassword { get; set; }
    }

    public class AccountEditViewModel : UserEditViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        [MinLength(8)]
        public string CurrentPassword { get; set; } = null!;
    }
}
