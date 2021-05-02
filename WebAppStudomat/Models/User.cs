using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppStudomat.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        public string Username { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}