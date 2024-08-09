using System.ComponentModel.DataAnnotations;

namespace BloggApp.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }
        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password),ErrorMessage = "Parolalar eşleşmiyor.")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        public string? ConfirmPassword { get; set; }
    }
}