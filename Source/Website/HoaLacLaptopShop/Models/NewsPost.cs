using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class NewsPost
{
    public int ID { get; set; }
    public int AuthorId { get; set; }
    public virtual User Author { get; set; } = null!;
    public string Token { get; set; } = null!;

    public DateTime Time { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(256)]
    public string Title { get; set; } = null!;
    public int WordCount { get; set; }
    public int ImageCount { get; set; }
    public int ReadingTime { get; set; }

    public NewsPostLength Length => ReadingTime switch
    {
        (<= 3) => NewsPostLength.Short,
        ( > 3) and (< 7) => NewsPostLength.Medium,
        (>= 7) => NewsPostLength.Long
    };
}

public enum NewsPostLength
{
    Short,
    Medium,
    Long
}
