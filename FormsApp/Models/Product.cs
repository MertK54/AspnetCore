using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace FormsApp.Models
{
    public class Product
    {
        [Display(Name = "Product İd")]
        public int ProductID { get; set; }
        [Display(Name = "Name")]
        [Required]
        [StringLength(20)]
        public string? Name { get; set; }
        [Required]
        [Display(Name = "Price")]
        [Range(0, 100000)]
        //decimal tipinde varsayılan değer 0'dır. Yani her zaman atanan değer vardır.
        //Required çalışması için null değer olma ihtimali olmalı o yüzden manuel olarak decimal?
        public decimal? Price { get; set; }
        [Display(Name = "Image")]
        public string? Image { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
    }
}