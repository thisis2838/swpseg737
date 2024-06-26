using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Administration.ViewModels
{
    public class UserIndexViewModel
    {
        public List<User> Users { get; set; } = null!;
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public string SearchTerm { get; set; }
    }
}
