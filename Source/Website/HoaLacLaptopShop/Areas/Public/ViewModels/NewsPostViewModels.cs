using HoaLacLaptopShop.Models;

namespace HoaLacLaptopShop.Areas.Public.ViewModels
{
    public class NewsPostIndexArgs
    {
        public string SearchTerm { get; set; } = null!;
    }
    public class NewsPostIndexViewModel : NewsPostIndexArgs
    {
        public List<NewsPost> Posts { get; init; } = null!;
    }

    public class NewsPostDetailsViewModel : NewsPost
    {
        public NewsPostDetailsViewModel() {; }
        public NewsPostDetailsViewModel(NewsPost post, string content)
        {
            Title = post.Title;
            Author = post.Author;
            ID = post.ID;
            Time = post.Time;
            Token = post.Token;
            AuthorId = post.AuthorId;

            Content = content;
        }
        public string? Content { get; set; } = null;
    }
}
