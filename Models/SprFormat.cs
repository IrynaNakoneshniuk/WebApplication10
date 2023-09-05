using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WebApplication10.Models;

public partial class SprFormat
{
    [DisplayName("Формат")]
    public string? Format { get; set; }

    public int Id { get; set; }
    [JsonIgnore]
    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
