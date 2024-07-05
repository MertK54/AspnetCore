using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class KursKayit
    {
        [Key]// Veritabanı bunun id olarak anlaması için Classİsmi+Id ya da Id isminde olmalı değilse [Key] belirtilmeli
        public int KayitId { get; set; }
        public int KursId { get; set; }
        public int OgrenciId { get; set; }
        public Ogrenci Ogrenci { get; set; } = null!;
        public Kurs Kurs { get; set; } = null!;
        public DateTime KayitTarihi { get; set; }

    }
}