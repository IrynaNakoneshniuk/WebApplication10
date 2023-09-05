using System.ComponentModel;

namespace WebApplication10.Models;

public partial class BooksNew
{
    [DisplayName("Ідентифікатор")]
    public int N { get; set; }
    [DisplayName("Код")]
    public double? Code { get; set; }
    [DisplayName("Нова")]
    public bool New { get; set; }
    [DisplayName("Назва")]
    public string? Name { get; set; }
    [DisplayName("Ціна")]
    public decimal? Price { get; set; }
    [DisplayName("Сторінок")]
    public double? Pages { get; set; }
    [DisplayName("Дата")]
    public DateTime? Date { get; set; }
    [DisplayName("Тираж")]
    public double? Pressrun { get; set; }
    [DisplayName("Видавництво")]
    public int? IzdId { get; set; }
    [DisplayName("Формат")]
    public int? FormatId { get; set; }
    [DisplayName("Тема")]
    public int? ThemesId { get; set; }
    [DisplayName("Категорія")]
    public int? KategoryId { get; set; }
    [DisplayName("Формат")]
    public virtual SprFormat? Format { get; set; }
    [DisplayName("Видавництво")]
    public virtual SprIzd? Izd { get; set; }
    [DisplayName("Категорія")]
    public virtual SprKategory? Kategory { get; set; }
    [DisplayName("Тема")]
    public virtual SprThemeTDO? Themes { get; set; }
}
