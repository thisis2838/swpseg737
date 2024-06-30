using HoaLacLaptopShop.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;

namespace HoaLacLaptopShop.Areas.Shared.ViewModels
{
    public class NewsPostIndexArgs
    {
        [MinLength(2), MaxLength(256), DisplayName("Title Search Term")]
        public string? SearchTerm { get; set; } = null;
        [MinLength(2), MaxLength(256), DisplayName("Author Search Term")]
        public string? PostedBy { get; set; } = null;

        [DataType(DataType.Date), DisplayName("Posted After Date")]
        public DateTime? PostedAfter { get; set; }
        [DataType(DataType.Date), DisplayName("Posted Before Date")]
        public DateTime? PostedBefore { get; set; }
        [DisplayName("Show Long Posts")]
        public bool ShowLong { get; set; } = true;
        [DisplayName("Show Medium Posts")]
        public bool ShowMedium { get; set; } = true;
        [DisplayName("Show Short Posts")]
        public bool ShowShort { get; set; } = true;
    }
    public class NewsPostIndexViewModel : NewsPostIndexArgs
    {
        public List<NewsPost> Posts { get; init; } = null!;
    }

    public class NewsPostDetailsViewModel : NewsPost
    {
        public string? Content { get; set; } = null;
    }
}
