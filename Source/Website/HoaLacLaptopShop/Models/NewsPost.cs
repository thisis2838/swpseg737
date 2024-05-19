using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoaLacLaptopShop.Models;

public partial class NewsPost
{
    public int ID { get; set; }
    [ReadOnly(true)]
    public DateTime Time { get; set; }
    [Required]
    public string Title { get; set; } = null!;
    [Required]
    public string Content { get; set; } = null!;
    [Required]
    public int? AuthorId { get; set; }
    public virtual User? Author { get; set; }
}
