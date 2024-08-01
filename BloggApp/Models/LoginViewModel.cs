using System.ComponentModel.DataAnnotations;

namespace BloggApp.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-Posta")]
        public string? Email { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password { get; set; }
    }
}