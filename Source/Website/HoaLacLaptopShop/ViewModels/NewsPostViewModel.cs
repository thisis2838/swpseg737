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

    public class NewsPostDetailsViewModel : NewsPost
    {
        public NewsPostDetailsViewModel() {; }
        public NewsPostDetailsViewModel(NewsPost post, string content)
        {
            this.Title = post.Title;
            this.Author = post.Author;
            this.ID = post.ID;
            this.Time = post.Time;
            this.Token = post.Token;
            this.AuthorId = post.AuthorId;

            this.Content = content;
        }
        public string? Content { get; set; } = null;
    }
}
