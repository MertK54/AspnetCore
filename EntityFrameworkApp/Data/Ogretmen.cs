using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogretmen
    {
        [Key]
        [Display(Name = "Öğretmenin Id")]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? AdSoyad
        {
            get { return this.Ad + " " + this.Soyad; }
        }
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girin.")]
        public string? Eposta { get; set; }
        [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
        public string? Telefon { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}