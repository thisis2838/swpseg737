using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class NewsPost
{
    public int ID { get; set; }
    public int? AuthorId { get; set; }
    public virtual User? Author { get; set; }

    public DateTime Time { get; set; }
    [Required(AllowEmptyStrings = false), MaxLength(256)]
    public string Title { get; set; } = null!;
    public string Token { get; set; } = null!;
}
