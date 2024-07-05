using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data;
public class Ogrenci
{
    [Key]
    [Display(Name = "Öğrenci Id")]
    public int OgrenciId { get; set; }
    [Display(Name = "Öğrenci Adı")]
    public string? OgrenciAd { get; set; }
    [Display(Name = "Öğrenci Soyadı")]
    public string? OgrenciSoyad { get; set; }
    [Display(Name = "Eposta")]
    public string AdSoyad
    {
        get { return this.OgrenciAd + " " + this.OgrenciSoyad; }
    }
    public string? Eposta { get; set; }
    [Display(Name = "Telefon")]
    public string? Telefon { get; set; }
    public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
}