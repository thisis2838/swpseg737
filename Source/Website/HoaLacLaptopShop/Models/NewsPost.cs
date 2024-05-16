using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Models;

public partial class NewsPost
{
    public int ID { get; set; }
    public DateTime Time { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
    public int? AuthorId { get; set; }
    public virtual User? Author { get; set; }
}
