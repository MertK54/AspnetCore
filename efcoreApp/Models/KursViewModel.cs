using System.ComponentModel.DataAnnotations;
using efcoreApp.Data;

namespace efcoreApp.Models;
public class KursViewModel
{
    [Key]
    public int KursId { get; set; }
    [Required]
    [StringLength(50)]
    public string? KursBaslik { get; set; }
    public int OgretmenId { get; set; }
    public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
}