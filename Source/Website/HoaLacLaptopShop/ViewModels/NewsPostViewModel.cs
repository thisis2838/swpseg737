using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.ViewModels
{
    public class NewsPostIndexArgs
    {
        public string SearchTerm { get; set; } = null!;
    }
    public class NewsPostIndexViewModel : NewsPostIndexArgs
    {
        public List<NewsPost> Posts { get; init; } = null!;
    }

    public class NewsPostEditArgs : NewsPost
    {
        public string Content { get; set; } = null!;
    }
}
