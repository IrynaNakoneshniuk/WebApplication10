using System.ComponentModel;
using System.Text.Json.Serialization;

namespace WebApplication10.Models;

public partial class SprIzd
{
    [DisplayName("Видавництво")]
    public string? Izd { get; set; }

    public int Id { get; set; }
    [JsonIgnore]
    public virtual ICollection<BooksNew> BooksNews { get; set; } = new List<BooksNew>();
}
