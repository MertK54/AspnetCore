using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data;
public class Kurs
{
    [Key]
    public int KursId { get; set; }
    public string? KursBaslik { get; set; }
    public int OgretmenId { get; set; }
    public Ogretmen Ogretmen { get; set; } = null!;
    public int? YeniSutunId { get; set; }
    public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
}