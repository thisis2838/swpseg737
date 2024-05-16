using System;
using System.Collections.Generic;

namespace HoaLacLaptopShop.Data;

public partial class NewsPost
{
    public int Id { get; set; }

    public DateTime Time { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;

    public int? Author { get; set; }

    public virtual User? AuthorNavigation { get; set; }
}
