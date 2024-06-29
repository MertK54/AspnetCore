using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "This is not an e-mail that complies with the e-mail rules.")]
        public string? Email { get; set; }
        [Required]
        public bool WillAttend { get; set; }
    }
}