using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ProductsApi.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Email { get; set; }= null!;
        [Required]
        public string Password { get; set; }= null!;
    }
    
}
