using HoaLacLaptopShop.Models;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class UserIndexViewArgs
    {
        [MinLength(2), MaxLength(255)]
        public string? Search { get; set; }
        [Range(1, int.MaxValue)]
        public int Page { get; set; } = 1;
    }

    public class UserIndexViewModel : UserIndexViewArgs
    {
        public required List<User> Users { get; set; } = null!;
        public required int TotalPages { get; set; }
    }
}
