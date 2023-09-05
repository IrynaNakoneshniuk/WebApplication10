using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WebApplication10.Models;

public partial class SprKategory
{
    [DisplayName("Категорія")]
    public string? Category { get; set; }

    public int Id { get; set; }
    [JsonIgnore]
    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
