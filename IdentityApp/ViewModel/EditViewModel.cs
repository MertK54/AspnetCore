using System.ComponentModel.DataAnnotations;

namespace IdentityApp.ViewModel
{
    public class EditViewModel
    {
        public string? FullName {get;set;}
        public string? Id {get;set;} 

        [EmailAddress]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public string? Password {get;set;} 

        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage = "Parola eşleşmedi")]
        public string? ConfirmPassword { get; set; } 
        public IList<string>? SelectedRoles {get;set;}
    }
}